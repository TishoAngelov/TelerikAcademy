-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2013 at 07:43 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `auction`
--
CREATE DATABASE IF NOT EXISTS `auction` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `auction`;

-- --------------------------------------------------------

--
-- Table structure for table `auctions`
--

CREATE TABLE IF NOT EXISTS `auctions` (
  `auction_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `date_created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `minimum_price` float NOT NULL,
  `date_end` datetime NOT NULL,
  `action_title` varchar(250) NOT NULL,
  `auction_desc` text NOT NULL,
  PRIMARY KEY (`auction_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `auctions`
--

INSERT INTO `auctions` (`auction_id`, `user_id`, `date_created`, `minimum_price`, `date_end`, `action_title`, `auction_desc`) VALUES
(11, 2, '2013-12-04 19:35:42', 2500.68, '2015-03-15 00:00:00', 'Laptop', 'mnogo e byrz'),
(10, 3, '2013-12-04 19:35:02', 8.5, '2015-09-15 00:00:00', 'Учебник по математика', 'много е запазен'),
(9, 3, '2013-12-04 19:34:02', 150.33, '2018-03-23 00:00:00', 'Trabant', 's4upen e ama ....');

-- --------------------------------------------------------

--
-- Table structure for table `auction_prices`
--

CREATE TABLE IF NOT EXISTS `auction_prices` (
  `price_id` int(11) NOT NULL AUTO_INCREMENT,
  `auction_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `price` float NOT NULL,
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`price_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `auction_prices`
--

INSERT INTO `auction_prices` (`price_id`, `auction_id`, `user_id`, `price`, `date_added`) VALUES
(8, 11, 2, 2500.68, '2013-12-04 19:35:42'),
(7, 10, 3, 8.5, '2013-12-04 19:35:02'),
(6, 9, 3, 150.33, '2013-12-04 19:34:02');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(250) NOT NULL,
  `password` varchar(40) NOT NULL,
  `date_registered` int(11) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `email`, `password`, `date_registered`) VALUES
(1, 'test@test.com', '4de4d95fc854e7883bec112a191c867c0678ca42', 1386144335),
(2, 'angelov.tisho@gmail.com', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', 1386167313),
(3, 'nqmam@abv.bg', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', 1386178089);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

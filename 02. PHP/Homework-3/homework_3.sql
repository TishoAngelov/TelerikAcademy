-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2013 at 10:52 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `homework_3`
--
CREATE DATABASE IF NOT EXISTS `homework_3` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `homework_3`;

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `message_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(50) NOT NULL,
  `message` text NOT NULL,
  `message_group` varchar(50) NOT NULL,
  `date_posted` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `user_posted` varchar(50) NOT NULL,
  PRIMARY KEY (`message_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`message_id`, `title`, `message`, `message_group`, `date_posted`, `user_posted`) VALUES
(8, 'Hello', 'zdraveite vsi4ki', '', '2013-10-09 23:51:57', 'robot'),
(7, 'Внимание!!!', 'Не псувайте!!!!!!!!!!!!!!', '', '2013-10-09 23:51:21', 'admin'),
(6, 'Test', 'some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test some test', 'Обща', '2013-10-09 23:50:48', 'go6o5');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL,
  `user_pass` varchar(50) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `user_name`, `user_pass`) VALUES
(1, 'admin', 'admin'),
(2, 'пешо', 'pesho'),
(3, 'ivan123', 'ivan123'),
(7, 'robot', 'robot'),
(6, 'go6o5', 'go6o5');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

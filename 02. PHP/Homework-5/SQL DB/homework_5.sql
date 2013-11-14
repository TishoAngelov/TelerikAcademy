-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2013 at 07:23 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `homework_5`
--
CREATE DATABASE IF NOT EXISTS `homework_5` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `homework_5`;

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE IF NOT EXISTS `authors` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT,
  `author_name` varchar(250) NOT NULL,
  PRIMARY KEY (`author_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`author_id`, `author_name`) VALUES
(1, 'Ivan'),
(2, 'Pesho'),
(3, 'Gosho'),
(4, 'Mariq');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE IF NOT EXISTS `books` (
  `book_id` int(11) NOT NULL AUTO_INCREMENT,
  `book_title` varchar(250) NOT NULL,
  `count_comments` int(10) unsigned NOT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_title`, `count_comments`) VALUES
(1, 'Knigata na Gosho', 1),
(2, 'Knigata na Ivan', 0),
(3, 'Knigata na Mariq', 3),
(4, 'Knigata na Ivan i Mariq', 1),
(5, 'Knigata na vsi4ki', 1);

-- --------------------------------------------------------

--
-- Table structure for table `books_authors`
--

CREATE TABLE IF NOT EXISTS `books_authors` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  KEY `book_id` (`book_id`),
  KEY `author_id` (`author_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books_authors`
--

INSERT INTO `books_authors` (`book_id`, `author_id`) VALUES
(1, 3),
(2, 1),
(3, 4),
(4, 4),
(5, 3),
(5, 1),
(5, 4),
(5, 2),
(4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `books_comments`
--

CREATE TABLE IF NOT EXISTS `books_comments` (
  `book_id` int(10) unsigned NOT NULL,
  `user_id` int(10) unsigned NOT NULL,
  `comment` text COLLATE utf8_bin NOT NULL,
  `date_posted` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `books_comments`
--

INSERT INTO `books_comments` (`book_id`, `user_id`, `comment`, `date_posted`) VALUES
(1, 1, 'admin: knigata na Gosho e mnogo dobra', '2013-10-27 18:32:41'),
(3, 1, 'admin: knigata na Mariq e mnogo dobra', '2013-10-27 18:33:10'),
(5, 1, 'admin: knigata na vsi4ki e mnogo dobra', '2013-10-27 18:33:28'),
(4, 2, 'Petko Ivanov: knigata na Ivan i Mariq e mnogo ZLE', '2013-10-27 18:38:45'),
(3, 3, 'Stoqn Stoqnov: Knigata na mariq ne struva i 1 lev...', '2013-10-27 18:44:49'),
(3, 1, 'admin: :)', '2013-10-27 19:05:27');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) COLLATE utf8_bin NOT NULL,
  `user_pass` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=4 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `user_name`, `user_pass`) VALUES
(1, 'admin', 'admin'),
(2, 'Petko Ivanov', 'petko123'),
(3, 'Stoqn Stoqnov', 'stoqn123');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

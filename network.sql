-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 31, 2022 at 08:23 AM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `network`
--

-- --------------------------------------------------------

--
-- Table structure for table `comp`
--

CREATE TABLE `comp` (
  `id` int(11) NOT NULL,
  `typ` text NOT NULL,
  `number` text NOT NULL,
  `load` text NOT NULL,
  `from_port` text NOT NULL,
  `to_port` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `comp`
--

INSERT INTO `comp` (`id`, `typ`, `number`, `load`, `from_port`, `to_port`) VALUES
(1, 'Switch', 'd55', '45', 'A0', 'A2'),
(2, 'Ethernet', 'kf88', '62', 'A0', 'A3'),
(3, 'PC', 'S44', '38', 'A0', 'A1'),
(4, 'Router', 'R33', '24', 'A1', 'A2'),
(6, 'PC', 'M34', '100', 'A1', 'A2');

-- --------------------------------------------------------

--
-- Table structure for table `traffic`
--

CREATE TABLE `traffic` (
  `id` int(11) NOT NULL,
  `from_port` text NOT NULL,
  `to_port` text NOT NULL,
  `max_load` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `traffic`
--

INSERT INTO `traffic` (`id`, `from_port`, `to_port`, `max_load`) VALUES
(1, 'A0', 'A2', 85),
(2, 'A0', 'A3', 310),
(3, 'A2', 'A3', 246),
(4, 'A2', 'A1', 494),
(5, 'A0', 'A1', 557),
(6, 'A3', 'A1', 302);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

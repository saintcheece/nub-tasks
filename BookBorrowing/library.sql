-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 02, 2023 at 01:12 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `library`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookinfo`
--

CREATE TABLE `bookinfo` (
  `bookcategory` varchar(4) NOT NULL,
  `bookcatdetail` varchar(15) NOT NULL,
  `bookid` varchar(8) NOT NULL,
  `booktitle` varchar(40) NOT NULL,
  `copynum` int(11) NOT NULL,
  `status` varchar(3) NOT NULL,
  `numberofdaysallowed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookinfo`
--

INSERT INTO `bookinfo` (`bookcategory`, `bookcatdetail`, `bookid`, `booktitle`, `copynum`, `status`, `numberofdaysallowed`) VALUES
('BC01', 'English', 'BC01-001', 'English Dictionary', 1, 'IN', 3),
('BC01', 'English', 'BC01-002', 'English for Dummies', 1, 'IN', 3),
('BC01', 'English', 'BC01-003', 'Hitchiker\'s Guide Vol 1', 1, 'IN', 3),
('BC01', 'English', 'BC01-006', 'Peanuts 1980-1989', 1, 'IN', 3),
('BC01', 'English', 'BC01-007', 'Divine Comedy', 1, 'IN', 3),
('BC01', 'English', 'BC01-008', 'Catcher and the Rye', 1, 'IN', 3),
('BC01', 'English', 'BC01-009', 'Diary of a Wimpy Kid', 1, 'IN', 3),
('BC01', 'English', 'BC01-010', 'Scott Pilgrim', 1, 'IN', 3),
('BC01', 'English', 'BC01-011', 'Death Hollows', 1, 'IN', 3),
('BC01', 'English', 'BC01-012', 'Scott Pilgrim Precious Little Hour', 1, 'IN', 3),
('BC01', 'English', 'BC01-013', 'King of Flies', 1, 'IN', 3),
('BC02', 'Mathematics', 'BC02-001', 'Basic Algebra', 1, 'IN', 3),
('BC02', 'Mathematics', 'BC02-002', 'Calculus for Dummies', 1, 'IN', 3),
('BC03', 'Social Science', 'BC03-001', 'Law Illustrated', 1, 'IN', 3),
('BC03', 'Social Science', 'BC03-002', 'Better Call Saul', 1, 'IN', 3);

-- --------------------------------------------------------

--
-- Table structure for table `borrowerinfo`
--

CREATE TABLE `borrowerinfo` (
  `borrowerid` varchar(8) NOT NULL,
  `borrowerName` varchar(30) NOT NULL,
  `course` varchar(6) NOT NULL,
  `section` varchar(6) NOT NULL,
  `numberofbooksallowed` int(11) NOT NULL,
  `numberofbooksborrowed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrowerinfo`
--

INSERT INTO `borrowerinfo` (`borrowerid`, `borrowerName`, `course`, `section`, `numberofbooksallowed`, `numberofbooksborrowed`) VALUES
('2023-001', 'Reece Santos', 'BSCpE', 'CPE303', 3, 0),
('2023-003', 'Rafael Landayan', 'BSHM', 'BHM402', 3, 0),
('2023-004', 'Hazel Landayan', 'BSHM', 'BHM401', 3, 0),
('2023-005', 'Simoun Philip Landayan', 'BSCpE', 'BCP401', 3, 0),
('2023-006', 'Ronmarc Gunita', 'BTA', 'BTA302', 3, 0),
('2023-007', 'Juan De La Cruz', 'BTA', 'BTA302', 3, 0);

-- --------------------------------------------------------

--
-- Table structure for table `transactioninfo`
--

CREATE TABLE `transactioninfo` (
  `transid` varchar(16) NOT NULL,
  `transcatid` varchar(6) NOT NULL,
  `transcatdetail` varchar(6) NOT NULL,
  `borrowerid` varchar(8) NOT NULL,
  `bookid` varchar(8) NOT NULL,
  `transdate` varchar(10) NOT NULL,
  `returndate` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookinfo`
--
ALTER TABLE `bookinfo`
  ADD PRIMARY KEY (`bookid`);

--
-- Indexes for table `borrowerinfo`
--
ALTER TABLE `borrowerinfo`
  ADD PRIMARY KEY (`borrowerid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

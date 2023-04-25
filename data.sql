-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (1,'milos','milos','red'),(2,'nikola','nikola','default'),(3,'marko','marko','default'),(4,'zarko','zarko','default'),(5,'vladan','vladan','red');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `brandname`
--

LOCK TABLES `brandname` WRITE;
/*!40000 ALTER TABLE `brandname` DISABLE KEYS */;
INSERT INTO `brandname` VALUES (1,'Audi'),(2,'BMW'),(3,'Mercedes');
/*!40000 ALTER TABLE `brandname` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `buy`
--

LOCK TABLES `buy` WRITE;
/*!40000 ALTER TABLE `buy` DISABLE KEYS */;
INSERT INTO `buy` VALUES (1,3,1,'2022-09-18'),(2,3,2,'2022-09-19'),(3,4,9,'2022-09-20'),(4,3,3,'2022-09-20'),(14,4,4,'2022-09-20'),(15,4,3,'2022-09-20'),(21,3,2,'2022-09-23'),(22,3,2,'2022-09-23'),(23,4,2,'2022-09-23'),(24,3,12,'2022-09-23'),(25,4,8,'2022-09-23'),(26,4,8,'2022-09-23'),(27,4,8,'2022-09-23'),(28,4,8,'2022-09-23'),(29,3,8,'2022-09-23'),(30,3,5,'2022-09-23'),(31,4,15,'2022-09-23'),(32,4,14,'2022-09-23'),(33,4,13,'2022-09-23'),(34,3,16,'2022-09-23'),(35,3,6,'2022-09-23'),(36,4,25,'2022-09-23'),(38,3,26,'2022-09-23'),(39,3,23,'2023-04-05'),(40,3,17,'2023-04-05'),(41,3,21,'2023-04-05');
/*!40000 ALTER TABLE `buy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `buyer`
--

LOCK TABLES `buyer` WRITE;
/*!40000 ALTER TABLE `buyer` DISABLE KEYS */;
INSERT INTO `buyer` VALUES (3),(4),(5);
/*!40000 ALTER TABLE `buyer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `dealership`
--

LOCK TABLES `dealership` WRITE;
/*!40000 ALTER TABLE `dealership` DISABLE KEYS */;
/*!40000 ALTER TABLE `dealership` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `model`
--

LOCK TABLES `model` WRITE;
/*!40000 ALTER TABLE `model` DISABLE KEYS */;
INSERT INTO `model` VALUES (1,1,'A4'),(2,1,'A5'),(3,1,'A6'),(4,2,'F30'),(5,2,'F10'),(6,3,'C Klasa'),(7,3,'E Klasa'),(8,3,'A Klasa');
/*!40000 ALTER TABLE `model` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Milos','Jacimovic',1,'CaraDusana'),(2,'Nikola','Markovic',1,'bb'),(3,'Marko','Nikolic',1,'bb'),(4,'Zarko','Zarkovic',1,'CaraDusana'),(5,'Vladan','Monkey',0,'bb');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `phonenumber`
--

LOCK TABLES `phonenumber` WRITE;
/*!40000 ALTER TABLE `phonenumber` DISABLE KEYS */;
INSERT INTO `phonenumber` VALUES (3,'044312345'),(4,'051940350'),(2,'064331423'),(1,'066294151'),(5,'44298214');
/*!40000 ALTER TABLE `phonenumber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `sale`
--

LOCK TABLES `sale` WRITE;
/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `salesbody`
--

LOCK TABLES `salesbody` WRITE;
/*!40000 ALTER TABLE `salesbody` DISABLE KEYS */;
INSERT INTO `salesbody` VALUES (1),(2);
/*!40000 ALTER TABLE `salesbody` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `salesman`
--

LOCK TABLES `salesman` WRITE;
/*!40000 ALTER TABLE `salesman` DISABLE KEYS */;
INSERT INTO `salesman` VALUES (1),(2);
/*!40000 ALTER TABLE `salesman` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `vehicle`
--

LOCK TABLES `vehicle` WRITE;
/*!40000 ALTER TABLE `vehicle` DISABLE KEYS */;
INSERT INTO `vehicle` VALUES (1,1,1,1,141,4,'Automatski','Dizel',5,'555-k-444',2013,0,1,0),(2,1,1,2,175,4,'Manuelac','Benzin',5,'223-j-551',2014,0,1,0),(3,2,1,1,130,4,'Manuleac','Dizel',5,'241-m-410',2009,0,1,0),(4,2,1,3,240,4,'Automatski','Benzin',4,'222-ll-jaj',2020,0,1,0),(5,1,3,8,140,4,'Manuelac','Benzin',4,'777-bl-105',2022,0,1,0),(6,2,2,5,250,4,'Automatski','Dizel',5,'987-ja-123',2014,0,1,0),(7,1,4,2,177,2,'Automatski','Benzin',2,'110-q-151',2015,0,1,0),(8,1,2,4,190,4,'Automatski','Benzin',5,'777-j-777',2017,0,1,0),(9,1,1,1,190,4,'Automatski','Dizel',4,'222l222',2012,0,1,0),(10,2,2,2,121,4,'Automatski','Dizel',4,'212-1231',2011,0,1,0),(11,1,2,2,120,4,'Automatski','Dizel',6,'22',2010,0,1,0),(12,1,1,4,250,4,'Automatski','Benzin',4,'222-k-123',2012,0,1,0),(13,2,3,2,210,4,'Manuelac','Dizel',4,'123-a-200',2020,0,1,0),(14,1,1,5,241,4,'Automatski','Benzin',5,'123-j-231',2015,0,1,0),(15,1,1,5,211,4,'Manuelac','Benzin',5,'111-j-113',2012,0,1,0),(16,1,1,2,140,4,'Manuelac','Dizel',5,'222-k-212',2010,0,1,0),(17,1,1,1,140,4,'Manuelac','Dizel',5,'123-j-321',2012,0,0,0),(21,1,3,2,177,4,'Manuelac','Benzin',4,'132-p-231',2015,0,1,0),(22,1,1,3,215,4,'Automatski','Dizel',5,'111111',2017,0,0,0),(23,1,1,5,210,4,'Automatski','Dizel',5,'1234',2016,0,1,0),(24,2,2,4,210,4,'Manuelac','Benzin',5,'210-j-241',2015,0,0,0),(25,2,2,5,140,4,'Manuelac','Benzin',5,'000-q-000',2010,0,1,0),(26,2,4,6,160,4,'Manuelac','Benzin',5,'210951',2012,0,1,0),(27,2,4,6,210,4,'Manuelac','Benzin',5,'111-o-222',2018,0,0,198000),(28,1,3,8,1,1,'Auto','Diesel',4,'394-k-321',1,0,1,1),(29,1,1,6,250,4,'Auto','Benzin',5,'345-m-412',2019,0,0,120322),(30,1,1,5,240,4,'Auto','Benzin',5,'123-lj-232',2018,0,0,129000);
/*!40000 ALTER TABLE `vehicle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `vehicletype`
--

LOCK TABLES `vehicletype` WRITE;
/*!40000 ALTER TABLE `vehicletype` DISABLE KEYS */;
INSERT INTO `vehicletype` VALUES (3,'Hecbek'),(4,'Kabriolet'),(2,'Karavan'),(1,'Limuzina');
/*!40000 ALTER TABLE `vehicletype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `waranty`
--

LOCK TABLES `waranty` WRITE;
/*!40000 ALTER TABLE `waranty` DISABLE KEYS */;
/*!40000 ALTER TABLE `waranty` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-20 23:01:19

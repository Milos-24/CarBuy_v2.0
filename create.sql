CREATE DATABASE  IF NOT EXISTS `mydb` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mydb`;
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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account` (
  `idAccount` int NOT NULL AUTO_INCREMENT,
  `username` varchar(15) NOT NULL,
  `password` varchar(15) NOT NULL,
  `theme` varchar(45) NOT NULL,
  PRIMARY KEY (`idAccount`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `brandname`
--

DROP TABLE IF EXISTS `brandname`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brandname` (
  `idBrandName` int NOT NULL AUTO_INCREMENT,
  `brandName` varchar(45) NOT NULL,
  PRIMARY KEY (`idBrandName`),
  UNIQUE KEY `brandName_UNIQUE` (`brandName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `buy`
--

DROP TABLE IF EXISTS `buy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buy` (
  `idBuy` int NOT NULL AUTO_INCREMENT,
  `idAccount` int NOT NULL,
  `idVehicle` int NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`idBuy`),
  KEY `fk_Vehicle_has_Buyer_Vehicle1_idx` (`idVehicle`),
  KEY `fk_Buy_Buyer1_idx` (`idAccount`),
  CONSTRAINT `fk_Buy_Buyer1` FOREIGN KEY (`idAccount`) REFERENCES `buyer` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_Vehicle_has_Buyer_Vehicle1` FOREIGN KEY (`idVehicle`) REFERENCES `vehicle` (`idVehicle`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `buyer`
--

DROP TABLE IF EXISTS `buyer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buyer` (
  `idAccount` int NOT NULL,
  PRIMARY KEY (`idAccount`),
  KEY `fk_Buyer_Person1_idx` (`idAccount`),
  CONSTRAINT `fk_Buyer_Person1` FOREIGN KEY (`idAccount`) REFERENCES `person` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dealership`
--

DROP TABLE IF EXISTS `dealership`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dealership` (
  `idAccount` int NOT NULL,
  `name` varchar(15) NOT NULL,
  `location` varchar(25) NOT NULL,
  PRIMARY KEY (`idAccount`),
  CONSTRAINT `fk_Dealership_SalesBody1` FOREIGN KEY (`idAccount`) REFERENCES `salesbody` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `model`
--

DROP TABLE IF EXISTS `model`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `model` (
  `idModel` int NOT NULL AUTO_INCREMENT,
  `idBrandName` int NOT NULL,
  `modelName` varchar(45) NOT NULL,
  PRIMARY KEY (`idModel`),
  UNIQUE KEY `modelName_UNIQUE` (`modelName`),
  KEY `fk_Model_BrandName1_idx` (`idBrandName`),
  CONSTRAINT `fk_Model_BrandName1` FOREIGN KEY (`idBrandName`) REFERENCES `brandname` (`idBrandName`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `person` (
  `idAccount` int NOT NULL,
  `name` varchar(20) NOT NULL,
  `lastName` varchar(20) NOT NULL,
  `sex` tinyint unsigned NOT NULL,
  `address` varchar(45) NOT NULL,
  PRIMARY KEY (`idAccount`),
  KEY `fk_Person_Account1_idx` (`idAccount`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk_Person_Account1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `phonenumber`
--

DROP TABLE IF EXISTS `phonenumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phonenumber` (
  `idAccount` int NOT NULL,
  `phoneNumber` varchar(15) NOT NULL,
  PRIMARY KEY (`idAccount`,`phoneNumber`),
  UNIQUE KEY `phoneNumber_UNIQUE` (`phoneNumber`),
  CONSTRAINT `fk_PhoneNumber_Account1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale` (
  `idSale` int NOT NULL AUTO_INCREMENT,
  `idWaranty` int DEFAULT NULL,
  `idAccount` int NOT NULL,
  `idVehicle` int NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`idSale`),
  KEY `fk_SalesBody_has_Vehicle_Vehicle1_idx` (`idVehicle`),
  KEY `fk_SalesBody_has_Vehicle_SalesBody1_idx` (`idAccount`),
  KEY `fk_Sale_Waranty1_idx` (`idWaranty`),
  CONSTRAINT `fk_Sale_Waranty1` FOREIGN KEY (`idWaranty`) REFERENCES `waranty` (`idWaranty`),
  CONSTRAINT `fk_SalesBody_has_Vehicle_SalesBody1` FOREIGN KEY (`idAccount`) REFERENCES `salesbody` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_SalesBody_has_Vehicle_Vehicle1` FOREIGN KEY (`idVehicle`) REFERENCES `vehicle` (`idVehicle`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `salesbody`
--

DROP TABLE IF EXISTS `salesbody`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salesbody` (
  `idAccount` int NOT NULL,
  PRIMARY KEY (`idAccount`),
  CONSTRAINT `fk_SalesBody_Account1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `salesman`
--

DROP TABLE IF EXISTS `salesman`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salesman` (
  `idAccount` int NOT NULL,
  PRIMARY KEY (`idAccount`),
  KEY `fk_SalesMan_Person1_idx` (`idAccount`),
  CONSTRAINT `fk_SalesMan_Person1` FOREIGN KEY (`idAccount`) REFERENCES `person` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_SalesMan_SalesBody1` FOREIGN KEY (`idAccount`) REFERENCES `salesbody` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vehicle`
--

DROP TABLE IF EXISTS `vehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicle` (
  `idVehicle` int NOT NULL AUTO_INCREMENT,
  `idAccount` int NOT NULL,
  `idVehicleType` int NOT NULL,
  `idModel` int NOT NULL,
  `horsePower` int unsigned NOT NULL,
  `numberOfDoors` int unsigned NOT NULL,
  `transmission` varchar(10) NOT NULL,
  `fuel` varchar(10) NOT NULL,
  `seatNumber` int unsigned NOT NULL,
  `registrationNumber` varchar(10) DEFAULT NULL,
  `makeYear` int unsigned NOT NULL,
  `load` int unsigned NOT NULL,
  `removed` tinyint(1) DEFAULT NULL,
  `milage` int unsigned NOT NULL,
  PRIMARY KEY (`idVehicle`),
  UNIQUE KEY `idVehicle_UNIQUE` (`idVehicle`),
  UNIQUE KEY `registrationNumber_UNIQUE` (`registrationNumber`),
  KEY `fk_Vehicle_Model1_idx` (`idModel`),
  KEY `fk_Vehicle_VehicleType1_idx` (`idVehicleType`),
  KEY `fk_Vehicle_SalesBody1_idx` (`idAccount`),
  CONSTRAINT `fk_Vehicle_Model1` FOREIGN KEY (`idModel`) REFERENCES `model` (`idModel`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_Vehicle_SalesBody1` FOREIGN KEY (`idAccount`) REFERENCES `salesbody` (`idAccount`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_Vehicle_VehicleType1` FOREIGN KEY (`idVehicleType`) REFERENCES `vehicletype` (`idVehicleType`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vehicletype`
--

DROP TABLE IF EXISTS `vehicletype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicletype` (
  `idVehicleType` int NOT NULL AUTO_INCREMENT,
  `vehicleType` varchar(25) NOT NULL,
  PRIMARY KEY (`idVehicleType`),
  UNIQUE KEY `carVehicle_UNIQUE` (`vehicleType`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `vehicleview`
--

DROP TABLE IF EXISTS `vehicleview`;
/*!50001 DROP VIEW IF EXISTS `vehicleview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vehicleview` AS SELECT 
 1 AS `idVehicleType`,
 1 AS `idBrandName`,
 1 AS `idModel`,
 1 AS `idVehicle`,
 1 AS `idAccount`,
 1 AS `horsePower`,
 1 AS `numberOfDoors`,
 1 AS `transmission`,
 1 AS `fuel`,
 1 AS `seatNumber`,
 1 AS `registrationNumber`,
 1 AS `makeYear`,
 1 AS `load`,
 1 AS `removed`,
 1 AS `modelName`,
 1 AS `brandName`,
 1 AS `vehicleType`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `waranty`
--

DROP TABLE IF EXISTS `waranty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `waranty` (
  `idWaranty` int NOT NULL AUTO_INCREMENT,
  `duration` int NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`idWaranty`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Final view structure for view `vehicleview`
--

/*!50001 DROP VIEW IF EXISTS `vehicleview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vehicleview` AS select `vehicle`.`idVehicleType` AS `idVehicleType`,`model`.`idBrandName` AS `idBrandName`,`vehicle`.`idModel` AS `idModel`,`vehicle`.`idVehicle` AS `idVehicle`,`vehicle`.`idAccount` AS `idAccount`,`vehicle`.`horsePower` AS `horsePower`,`vehicle`.`numberOfDoors` AS `numberOfDoors`,`vehicle`.`transmission` AS `transmission`,`vehicle`.`fuel` AS `fuel`,`vehicle`.`seatNumber` AS `seatNumber`,`vehicle`.`registrationNumber` AS `registrationNumber`,`vehicle`.`makeYear` AS `makeYear`,`vehicle`.`load` AS `load`,`vehicle`.`removed` AS `removed`,`model`.`modelName` AS `modelName`,`brandname`.`brandName` AS `brandName`,`vehicletype`.`vehicleType` AS `vehicleType` from (((`vehicle` join `model` on((`vehicle`.`idModel` = `model`.`idModel`))) join `brandname` on((`model`.`idBrandName` = `brandname`.`idBrandName`))) join `vehicletype` on((`vehicle`.`idVehicleType` = `vehicletype`.`idVehicleType`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-20 23:03:34

-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 10.0.225.117    Database: dc
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.26-MariaDB-0+deb9u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dc_action`
--

DROP TABLE IF EXISTS `dc_action`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_action` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) NOT NULL DEFAULT '0',
  `uuid` varchar(36) NOT NULL,
  `name` varchar(255) DEFAULT 'action name',
  PRIMARY KEY (`id`),
  UNIQUE KEY `guid_UNIQUE` (`uuid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='DC action types';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_action`
--

LOCK TABLES `dc_action` WRITE;
/*!40000 ALTER TABLE `dc_action` DISABLE KEYS */;
INSERT INTO `dc_action` VALUES (1,0,'3413cab4-d5a3-11e7-a949-1e9f2883c798','logon'),(2,0,'3abeb964-d5a3-11e7-a949-1e9f2883c798','logoff');
/*!40000 ALTER TABLE `dc_action` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`admin`@`%`*/ /*!50003 TRIGGER `dc`.`dc_action_BEFORE_INSERT` BEFORE INSERT ON `dc_action` FOR EACH ROW
BEGIN
SET NEW.uuid = uuid();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `dc_cfg`
--

DROP TABLE IF EXISTS `dc_cfg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_cfg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) DEFAULT '0',
  `key` varchar(255) NOT NULL DEFAULT '',
  `value` text,
  `info` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `key_UNIQUE` (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_cfg`
--

LOCK TABLES `dc_cfg` WRITE;
/*!40000 ALTER TABLE `dc_cfg` DISABLE KEYS */;
/*!40000 ALTER TABLE `dc_cfg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dc_log`
--

DROP TABLE IF EXISTS `dc_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) NOT NULL DEFAULT '0',
  `user_id` int(11) NOT NULL,
  `action_id` int(11) NOT NULL,
  `type_id` int(11) NOT NULL,
  `object_id` int(11) DEFAULT NULL,
  `object_full_name` varchar(255) NOT NULL DEFAULT '',
  `params` text,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `remote_ip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `dc_action_id_idx` (`action_id`),
  KEY `dc_type_id_idx` (`type_id`),
  KEY `dc_user_id_idx` (`user_id`),
  CONSTRAINT `dc_action_id` FOREIGN KEY (`action_id`) REFERENCES `dc_action` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dc_type_id` FOREIGN KEY (`type_id`) REFERENCES `dc_type` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dc_user_id` FOREIGN KEY (`user_id`) REFERENCES `dc_user` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COMMENT='DC log messages';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_log`
--

LOCK TABLES `dc_log` WRITE;
/*!40000 ALTER TABLE `dc_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `dc_log` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`admin`@`%`*/ /*!50003 TRIGGER `dc`.`dc_log_BEFORE_INSERT` BEFORE INSERT ON `dc_log` FOR EACH ROW
BEGIN
SET NEW.remote_ip = (SELECT SUBSTRING_INDEX(USER(), '@', -1));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `dc_status`
--

DROP TABLE IF EXISTS `dc_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) NOT NULL DEFAULT '0',
  `uuid` varchar(36) NOT NULL DEFAULT '',
  `name` varchar(255) DEFAULT '',
  PRIMARY KEY (`id`),
  UNIQUE KEY `guid_UNIQUE` (`uuid`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='DC status types';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_status`
--

LOCK TABLES `dc_status` WRITE;
/*!40000 ALTER TABLE `dc_status` DISABLE KEYS */;
INSERT INTO `dc_status` VALUES (0,0,'52df4c1f-d093-11e7-a949-1e9f2883c798','default');
/*!40000 ALTER TABLE `dc_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dc_type`
--

DROP TABLE IF EXISTS `dc_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_type` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) NOT NULL DEFAULT '0',
  `uuid` varchar(36) NOT NULL DEFAULT '',
  `name` varchar(255) NOT NULL DEFAULT '',
  `table` varchar(255) NOT NULL COMMENT 'table for htis object type in DC schema\n',
  PRIMARY KEY (`id`),
  UNIQUE KEY `table_UNIQUE` (`table`),
  UNIQUE KEY `guid_UNIQUE` (`uuid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='DC object types';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_type`
--

LOCK TABLES `dc_type` WRITE;
/*!40000 ALTER TABLE `dc_type` DISABLE KEYS */;
INSERT INTO `dc_type` VALUES (1,0,'dd1b35f7-d5a3-11e7-a949-1e9f2883c798','user','dc_user');
/*!40000 ALTER TABLE `dc_type` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`admin`@`%`*/ /*!50003 TRIGGER `dc`.`dc_type_BEFORE_INSERT` BEFORE INSERT ON `dc_type` FOR EACH ROW
BEGIN
SET NEW.uuid = uuid();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `dc_user`
--

DROP TABLE IF EXISTS `dc_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dc_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `version` int(11) NOT NULL DEFAULT '0',
  `uuid` varchar(36) NOT NULL COMMENT 'dc object guid',
  `type_id` int(11) NOT NULL DEFAULT '1',
  `create_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `name` varchar(32) NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL DEFAULT '',
  `passwd` varchar(255) NOT NULL DEFAULT '',
  `allow_winauth` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  `last_logon` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `info` text NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `guid_UNIQUE` (`uuid`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `dc_status_id_idx` (`status`),
  CONSTRAINT `dc_status_id` FOREIGN KEY (`status`) REFERENCES `dc_status` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='DC users';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dc_user`
--

LOCK TABLES `dc_user` WRITE;
/*!40000 ALTER TABLE `dc_user` DISABLE KEYS */;
INSERT INTO `dc_user` VALUES (0,0,'f06f4bd2-d0a9-11e7-a949-1e9f2883c798',1,'2017-11-23 23:56:35','admin','DCIM Administrator','','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',0,0,'2017-11-30 13:13:37',''),(4,0,'9022a1ca-d0cc-11e7-a949-1e9f2883c798',1,'2017-11-24 04:04:26','n5201-00-054','Конвовалов Александр Вячеславовович','','',1,0,'2017-11-30 13:16:55','');
/*!40000 ALTER TABLE `dc_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`admin`@`%`*/ /*!50003 TRIGGER `dc`.`dc_user_BEFORE_INSERT` BEFORE INSERT ON `dc_user` FOR EACH ROW
BEGIN
SET NEW.uuid = uuid();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `log_view`
--

DROP TABLE IF EXISTS `log_view`;
/*!50001 DROP VIEW IF EXISTS `log_view`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `log_view` AS SELECT 
 1 AS `timestamp`,
 1 AS `remote_ip`,
 1 AS `name`,
 1 AS `action`,
 1 AS `type`,
 1 AS `object_id`,
 1 AS `object_full_name`,
 1 AS `params`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'dc'
--

--
-- Dumping routines for database 'dc'
--
/*!50003 DROP FUNCTION IF EXISTS `logon` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`dc_admin`@`%` FUNCTION `logon`(
        `user_name` VARCHAR(255),
        `user_password` VARCHAR(255)
    ) RETURNS int(11)
    MODIFIES SQL DATA
    DETERMINISTIC
BEGIN   
  DECLARE user_id INT;
  DECLARE winauth INT;
  DECLARE stat INT;
  DECLARE result INT DEFAULT -1; 
  
  select `allow_winauth`, `status` into winauth, stat from `dc_user` where `name`=user_name limit 1;
  if stat = 0 then
	if winauth = 1 then
		set result = 1;
		update `dc_user` set `last_logon`=CURRENT_TIMESTAMP() where `name`=user_name;
	end if;
	if winauth = 0 then
		select `id` into user_id from `dc_user` where `name`=user_name and `passwd`=sha2(user_password, 256) limit 1;
	    if user_id is not null then  
			set result = 2;
			update `dc_user` set `last_logon`=CURRENT_TIMESTAMP() where `name`=user_name;
	    end if;
	end if;
  end if;
  return result;
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `log` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`dc_admin`@`%` PROCEDURE `log`(
        IN `user_id` INTEGER,
        IN `action_id` INTEGER,
        IN `type_id` INTEGER,
        IN `object_id` INTEGER,
        IN `object_full_name` VARCHAR(255),
        IN `params` TEXT
    )
    MODIFIES SQL DATA
    DETERMINISTIC
BEGIN
	insert into `dc_log` (`user_id`, `action_id`, `type_id`, `object_id`, `object_full_name`, `params`) values(user_id, action_id, type_id, object_id, object_full_name, params);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `user_get` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ALLOW_INVALID_DATES,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`dc_admin`@`%` PROCEDURE `user_get`(
        IN `user_name` VARCHAR(255)
    )
    READS SQL DATA
    DETERMINISTIC
BEGIN
	select id, version, uuid, type_id, create_time, name, full_name, email, allow_winauth, status, last_logon, info from dc_user where name=user_name limit 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `user_list` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`admin`@`%` PROCEDURE `user_list`()
    READS SQL DATA
    DETERMINISTIC
BEGIN
	select id, version, uuid, type_id, create_time, name, email, allow_winauth, status, last_logon, info, full_name from dc_user;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `log_view`
--

/*!50001 DROP VIEW IF EXISTS `log_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`admin`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `log_view` AS select `dc_log`.`timestamp` AS `timestamp`,`dc_log`.`remote_ip` AS `remote_ip`,`dc_user`.`full_name` AS `name`,`dc_action`.`name` AS `action`,`dc_type`.`name` AS `type`,`dc_log`.`object_id` AS `object_id`,`dc_log`.`object_full_name` AS `object_full_name`,`dc_log`.`params` AS `params` from (((`dc_log` join `dc_user` on((`dc_log`.`user_id` = `dc_user`.`id`))) join `dc_action` on((`dc_log`.`action_id` = `dc_action`.`id`))) join `dc_type` on((`dc_log`.`type_id` = `dc_type`.`id`))) */;
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

-- Dump completed on 2017-11-30 16:27:27

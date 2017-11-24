/* SQL Manager Lite for MySQL                              5.6.4.50082 */
/* ------------------------------------------------------------------- */
/* Host     : 10.0.225.117                                             */
/* Port     : 3306                                                     */
/* Database : dc                                                       */


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES 'utf8' */;

SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS `dc`;

CREATE DATABASE `dc`
    CHARACTER SET 'utf8'
    COLLATE 'utf8_general_ci';

USE `dc`;

/* Dropping database objects */

DROP TABLE IF EXISTS `dc_log`;
DROP TABLE IF EXISTS `dc_type`;
DROP TABLE IF EXISTS `dc_session`;
DROP TABLE IF EXISTS `dc_user`;
DROP TABLE IF EXISTS `dc_status`;
DROP TABLE IF EXISTS `dc_action`;

/* Structure for the `dc_action` table : */

CREATE TABLE `dc_action` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `uuid` VARCHAR(36) COLLATE utf8_general_ci NOT NULL,
  `name` VARCHAR(255) COLLATE utf8_general_ci DEFAULT 'action name',
  PRIMARY KEY USING BTREE (`id`),
  UNIQUE KEY `guid_UNIQUE` USING BTREE (`uuid`)
) ENGINE=InnoDB
AUTO_INCREMENT=1 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT='DC action types'
;

/* Structure for the `dc_status` table : */

CREATE TABLE `dc_status` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `uuid` VARCHAR(36) COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `name` VARCHAR(255) COLLATE utf8_general_ci DEFAULT '',
  PRIMARY KEY USING BTREE (`id`),
  UNIQUE KEY `guid_UNIQUE` USING BTREE (`uuid`),
  UNIQUE KEY `name_UNIQUE` USING BTREE (`name`)
) ENGINE=InnoDB
AUTO_INCREMENT=3 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT='DC status types'
;

/* Structure for the `dc_user` table : */

CREATE TABLE `dc_user` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `uuid` VARCHAR(36) COLLATE utf8_general_ci NOT NULL COMMENT 'dc object guid',
  `create_time` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `name` VARCHAR(32) COLLATE utf8_general_ci NOT NULL,
  `email` VARCHAR(255) COLLATE utf8_general_ci DEFAULT NULL,
  `passwd` VARCHAR(255) COLLATE utf8_general_ci NOT NULL,
  `allow_winauth` INTEGER(11) DEFAULT 0,
  `status` INTEGER(11) NOT NULL DEFAULT 0,
  `last_logon` TIMESTAMP NULL DEFAULT NULL,
  `info` TEXT COLLATE utf8_general_ci,
  PRIMARY KEY USING BTREE (`id`),
  UNIQUE KEY `guid_UNIQUE` USING BTREE (`uuid`),
  UNIQUE KEY `name_UNIQUE` USING BTREE (`name`),
  KEY `dc_status_id_idx` USING BTREE (`status`),
  CONSTRAINT `dc_status_id` FOREIGN KEY (`status`) REFERENCES `dc_status` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB
AUTO_INCREMENT=4 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT='DC users'
;

/* Structure for the `dc_session` table : */

CREATE TABLE `dc_session` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `uuid` VARCHAR(36) COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `user_id` INTEGER(11) DEFAULT NULL,
  `remote_ip` VARCHAR(255) COLLATE utf8_general_ci DEFAULT NULL,
  `timestamp` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY USING BTREE (`id`),
  UNIQUE KEY `guid_UNIQUE` USING BTREE (`uuid`),
  KEY `dc_user_id_idx` USING BTREE (`user_id`),
  CONSTRAINT `dc_user_id` FOREIGN KEY (`user_id`) REFERENCES `dc_user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB
AUTO_INCREMENT=1 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
;

/* Structure for the `dc_type` table : */

CREATE TABLE `dc_type` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `uuid` VARCHAR(36) COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `name` VARCHAR(255) COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `table` VARCHAR(255) COLLATE utf8_general_ci NOT NULL COMMENT 'table for htis object type in DC schema',
  PRIMARY KEY USING BTREE (`id`),
  UNIQUE KEY `table_UNIQUE` USING BTREE (`table`),
  UNIQUE KEY `guid_UNIQUE` USING BTREE (`uuid`)
) ENGINE=InnoDB
AUTO_INCREMENT=1 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT='DC object types'
;

/* Structure for the `dc_log` table : */

CREATE TABLE `dc_log` (
  `id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `version` INTEGER(11) NOT NULL DEFAULT 0,
  `session_id` INTEGER(11) NOT NULL,
  `action_id` INTEGER(11) NOT NULL,
  `type_id` INTEGER(11) NOT NULL,
  `object_id` INTEGER(11) DEFAULT NULL,
  `params` TEXT COLLATE utf8_general_ci,
  PRIMARY KEY USING BTREE (`id`),
  KEY `dc_action_id_idx` USING BTREE (`action_id`),
  KEY `dc_type_id_idx` USING BTREE (`type_id`),
  KEY `dc_session_id_idx` USING BTREE (`session_id`),
  CONSTRAINT `dc_action_id` FOREIGN KEY (`action_id`) REFERENCES `dc_action` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dc_session_id` FOREIGN KEY (`session_id`) REFERENCES `dc_session` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dc_type_id` FOREIGN KEY (`type_id`) REFERENCES `dc_type` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB
AUTO_INCREMENT=1 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT='DC log messages'
;

/* Data for the `dc_status` table  (LIMIT 0,500) */

INSERT INTO `dc_status` (`id`, `version`, `uuid`, `name`) VALUES
  (0,0,'52df4c1f-d093-11e7-a949-1e9f2883c798','default');
COMMIT;

UPDATE `dc_status` SET id=0 WHERE id=LAST_INSERT_ID();
COMMIT;
/* Data for the `dc_user` table  (LIMIT 0,500) */

INSERT INTO `dc_user` (`id`, `version`, `uuid`, `create_time`, `name`, `email`, `passwd`, `allow_winauth`, `status`, `last_logon`, `info`) VALUES
  (0,0,'f06f4bd2-d0a9-11e7-a949-1e9f2883c798','2017-11-24 02:56:35','admin',NULL,'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',0,0,NULL,NULL);
COMMIT;

UPDATE `dc_user` SET id=0 WHERE id=LAST_INSERT_ID();
COMMIT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
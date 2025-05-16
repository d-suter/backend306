CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `Cohorts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Profession` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Baccalaureate` tinyint(1) NOT NULL,
        `SchoolYear` tinyint unsigned NOT NULL,
        `FirstSchoolYear` int unsigned NOT NULL,
        `ClassNameVocationalEducation` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ClassNameBaccalaureate` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Cohorts` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `Results` (
        `ID` int NOT NULL AUTO_INCREMENT,
        `Grade` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Points` int unsigned NOT NULL,
        `MedicineBallPush` int NOT NULL,
        `StandingLongJump` int NOT NULL,
        `CoreStrength` int NOT NULL,
        `OneLegStand` int NOT NULL,
        `ShuttleRun` int NOT NULL,
        `TwelveMinutesRun` float NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_Results` PRIMARY KEY (`ID`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `CoreStrengthAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ResultInSeconds` int unsigned NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_CoreStrengthAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_CoreStrengthAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `MedicineBallPushAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ResultInCentimeters` int unsigned NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_MedicineBallPushAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_MedicineBallPushAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `OneLegStandAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Foot` int NOT NULL,
        `ResultInSeconds` int unsigned NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_OneLegStandAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_OneLegStandAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `ShuttleRunAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ResultInMilliseconds` int unsigned NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_ShuttleRunAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_ShuttleRunAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `StandingLongJumpAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ResultInCentimeters` int unsigned NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_StandingLongJumpAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_StandingLongJumpAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE TABLE `TwelveMinutesRunAttempts` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ResultInRounds` float NOT NULL,
        `AttemptNumber` tinyint unsigned NOT NULL,
        `Points` int unsigned NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Gender` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `CohortId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_TwelveMinutesRunAttempts` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_TwelveMinutesRunAttempts_Cohorts_CohortId` FOREIGN KEY (`CohortId`) REFERENCES `Cohorts` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    INSERT INTO `Results` (`ID`, `CoreStrength`, `Gender`, `Grade`, `MedicineBallPush`, `OneLegStand`, `Points`, `ShuttleRun`, `StandingLongJump`, `TwelveMinutesRun`)
    VALUES (1, 0, 'm', 'TE', 0, 0, 0, 100000, 0, 0),
    (2, 5, 'm', 'TE', 410, 11, 1, 12260, 165, 31),
    (3, 10, 'm', 'TE', 420, 14, 2, 12120, 170, 31.5),
    (4, 15, 'm', 'TE', 430, 17, 3, 11980, 175, 32),
    (5, 20, 'm', 'TE', 440, 20, 4, 11840, 180, 32.5),
    (6, 25, 'm', 'TE', 450, 23, 5, 11700, 185, 33),
    (7, 30, 'm', 'TE', 470, 26, 6, 11560, 190, 33.5),
    (8, 40, 'm', 'EE', 490, 29, 7, 11420, 195, 34.5),
    (9, 50, 'm', 'EE', 510, 31, 8, 11280, 200, 35),
    (10, 60, 'm', 'EE', 530, 33, 9, 11140, 205, 35.5),
    (11, 70, 'm', 'EE', 550, 35, 10, 11000, 210, 36),
    (12, 80, 'm', 'EE', 570, 37, 11, 10860, 215, 36.5),
    (13, 90, 'm', 'EE', 590, 39, 12, 10720, 220, 37.5),
    (14, 100, 'm', 'EE', 610, 41, 13, 10580, 225, 38),
    (15, 110, 'm', 'EE', 630, 43, 14, 10440, 230, 38.5),
    (16, 120, 'm', 'EE', 650, 45, 15, 10300, 235, 39),
    (17, 130, 'm', 'UEE', 670, 47, 16, 10160, 240, 39.5),
    (18, 145, 'm', 'UEE', 690, 49, 17, 10020, 245, 40.5),
    (19, 160, 'm', 'UEE', 710, 51, 18, 9880, 250, 41),
    (20, 175, 'm', 'UEE', 730, 54, 19, 9740, 255, 41.5),
    (21, 190, 'm', 'UEE', 750, 58, 20, 9600, 260, 42),
    (22, 210, 'm', 'UEE', 770, 64, 21, 9460, 265, 42.5),
    (23, 230, 'm', 'UED', 790, 71, 22, 9320, 270, 43.5),
    (24, 250, 'm', 'UED', 810, 79, 23, 9180, 275, 44),
    (25, 270, 'm', 'UED', 830, 88, 24, 9040, 280, 44.5),
    (26, 290, 'm', 'UED', 850, 100, 25, 8900, 285, 45),
    (27, 0, 'f', 'TE', 0, 0, 0, 100000, 0, 0),
    (28, 5, 'f', 'TE', 316, 11, 1, 13000, 116, 24),
    (29, 9, 'f', 'TE', 321, 14, 2, 12950, 119, 24.5),
    (30, 14, 'f', 'TE', 327, 17, 3, 12820, 123, 25),
    (31, 18, 'f', 'TE', 332, 20, 4, 12680, 126, 26),
    (32, 23, 'f', 'TE', 338, 23, 5, 12540, 130, 26.5),
    (33, 27, 'f', 'TE', 349, 26, 6, 12400, 133, 27),
    (34, 36, 'f', 'EE', 360, 29, 7, 12270, 137, 28),
    (35, 45, 'f', 'EE', 371, 31, 8, 12130, 140, 28.5),
    (36, 54, 'f', 'EE', 382, 33, 9, 11990, 144, 29),
    (37, 63, 'f', 'EE', 393, 35, 10, 11860, 147, 30),
    (38, 72, 'f', 'EE', 404, 37, 11, 11720, 151, 30.5),
    (39, 81, 'f', 'EE', 415, 39, 12, 11580, 154, 31),
    (40, 90, 'f', 'EE', 426, 41, 13, 11440, 158, 32),
    (41, 99, 'f', 'EE', 437, 43, 14, 11310, 161, 32.5),
    (42, 108, 'f', 'EE', 448, 45, 15, 11170, 165, 33);
    INSERT INTO `Results` (`ID`, `CoreStrength`, `Gender`, `Grade`, `MedicineBallPush`, `OneLegStand`, `Points`, `ShuttleRun`, `StandingLongJump`, `TwelveMinutesRun`)
    VALUES (43, 117, 'f', 'UEE', 459, 47, 16, 11030, 168, 34),
    (44, 131, 'f', 'UEE', 470, 49, 17, 10900, 172, 34.5),
    (45, 144, 'f', 'UEE', 481, 51, 18, 10760, 175, 35),
    (46, 158, 'f', 'UEE', 492, 54, 19, 10620, 179, 36),
    (47, 171, 'f', 'UEE', 503, 58, 20, 10480, 182, 36.5),
    (48, 189, 'f', 'UEE', 514, 64, 21, 10360, 186, 37),
    (49, 207, 'f', 'UED', 525, 71, 22, 10220, 189, 38),
    (50, 225, 'f', 'UED', 536, 79, 23, 10080, 193, 38.5),
    (51, 243, 'f', 'UED', 547, 88, 24, 9940, 196, 39),
    (52, 261, 'f', 'UED', 558, 100, 25, 9800, 200, 40);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_CoreStrengthAttempts_CohortId` ON `CoreStrengthAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_MedicineBallPushAttempts_CohortId` ON `MedicineBallPushAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_OneLegStandAttempts_CohortId` ON `OneLegStandAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_ShuttleRunAttempts_CohortId` ON `ShuttleRunAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_StandingLongJumpAttempts_CohortId` ON `StandingLongJumpAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    CREATE INDEX `IX_TwelveMinutesRunAttempts_CohortId` ON `TwelveMinutesRunAttempts` (`CohortId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018194544_InitialMigration') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20241018194544_InitialMigration', '8.0.8');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `TwelveMinutesRunAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `StandingLongJumpAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `ShuttleRunAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `OneLegStandAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `MedicineBallPushAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    ALTER TABLE `CoreStrengthAttempts` ADD `MomentUtc` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20241018202630_AttemptMoment') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20241018202630_AttemptMoment', '8.0.8');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;


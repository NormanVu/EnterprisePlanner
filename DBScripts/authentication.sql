-- Structure for table enterpriseplanner.aspnetusers
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(100) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL DEFAULT 0,
  `ConcurrencyStamp` varchar(100) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL DEFAULT b'0',
  `FirstName` varchar(150) DEFAULT NULL,
  `LastName` varchar(150) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL DEFAULT b'1',
  `LockoutEnd` datetime DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `PhoneNumber` varchar(50) DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL DEFAULT b'0',
  `SecurityStamp` varchar(100) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL DEFAULT b'0',
  `UserName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(100) NOT NULL,
  `SecurityStamp` varchar(100) DEFAULT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `usertokens`;
CREATE TABLE IF NOT EXISTS `usertokens` (
  `UserId` varchar(100) NOT NULL,
  `LoginProvider` varchar(100) NOT NULL,
  `Name` varchar(256) NOT NULL,
  `Value` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `approles`;
CREATE TABLE IF NOT EXISTS `approles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdentityId` varchar(100) NOT NULL,
  `Location` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_approles_identityid` (`IdentityId`),
  CONSTRAINT `fk_approles_identityid` FOREIGN KEY (`IdentityId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `userclaims`;
CREATE TABLE IF NOT EXISTS `userclaims` (
  `Id` varchar(100) NOT NULL,
  `ClaimType` varchar(100) DEFAULT NULL,
  `ClaimValue` varchar(100) DEFAULT NULL,
  `UserId` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_userclaims_userid` (`UserId`),
  CONSTRAINT `fk_userclaims_userid` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `userlogins`;
CREATE TABLE IF NOT EXISTS `userlogins` (
  `LoginProvider` varchar(100) NOT NULL,
  `ProviderKey` varchar(100) NOT NULL,
  `ProviderDisplayName` varchar(100) DEFAULT NULL,
  `UserId` varchar(100) NOT NULL,
  PRIMARY KEY (`LoginProvider`, `ProviderKey`),
  KEY `fk_userlogins_userid` (`UserId`),
  CONSTRAINT `fk_userlogins_userid` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `roleclaims`;
CREATE TABLE IF NOT EXISTS `roleclaims` (
  `Id` varchar(100) NOT NULL,
  `ClaimType` varchar(100) DEFAULT NULL,
  `ClaimValue` varchar(100) DEFAULT NULL,
  `RoleId` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_roleclaims_roleid` (`RoleId`),
  CONSTRAINT `fk_roleclaims_roleid` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `userroles`;
CREATE TABLE IF NOT EXISTS `userroles` (
  `UserId` varchar(100) NOT NULL,
  `RoleId` varchar(100) NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`),
  KEY `fk_userroles_userid` (`UserId`),
  KEY `fk_userroles_roleid` (`RoleId`),
  CONSTRAINT `fk_userroles_userid` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `fk_userroles_roleid` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
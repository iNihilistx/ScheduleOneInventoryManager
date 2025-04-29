CREATE TABLE `product_table` (
	`ProductID` INT(11) NOT NULL AUTO_INCREMENT,
	`ProductName` VARCHAR(255) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_uca1400_ai_ci',
	`ProductPrice` INT(11) NOT NULL DEFAULT '0',
	`ProductQuantity` BIGINT(255) NOT NULL DEFAULT '0',
	`ProductIngredients` VARCHAR(255) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_uca1400_ai_ci',
	`ProductQuality` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_uca1400_ai_ci',
	`ProductSelling` INT(11) NOT NULL DEFAULT '0',
	`UserID` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`ProductID`) USING BTREE,
	INDEX `fk_product_userid` (`UserID`) USING BTREE,
	CONSTRAINT `fk_product_userid` FOREIGN KEY (`UserID`) REFERENCES `user_table` (`LoginID`) ON UPDATE NO ACTION ON DELETE NO ACTION
)
COLLATE='utf8mb4_uca1400_ai_ci'
ENGINE=InnoDB
AUTO_INCREMENT=13
;

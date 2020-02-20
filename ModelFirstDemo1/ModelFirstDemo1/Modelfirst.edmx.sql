
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/17/2020 11:49:07
-- Generated from EDMX file: D:\EntityFramework\ModelFirstDemo1\ModelFirstDemo1\Modelfirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Productdets'
CREATE TABLE [dbo].[Productdets] (
    [Pid] int IDENTITY(1,1) NOT NULL,
    [Pname] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [Cid] int  NOT NULL constraint fk_pd foreign key references Categorydets(Cid)
);
GO

-- Creating table 'Categorydets'
CREATE TABLE [dbo].[Categorydets] (
    [Cid] int IDENTITY(1,1) NOT NULL Primary key,
    [Cname] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Pid] in table 'Productdets'
ALTER TABLE [dbo].[Productdets]
ADD CONSTRAINT [PK_Productdets]
    PRIMARY KEY CLUSTERED ([Pid] ASC);
GO

-- Creating primary key on [Cid] in table 'Categorydets'
ALTER TABLE [dbo].[Categorydets]
ADD CONSTRAINT [PK_Categorydets]
    PRIMARY KEY CLUSTERED ([Cid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
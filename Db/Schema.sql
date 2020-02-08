-- Script Date: 2/8/2020 1:14 PM  - ErikEJ.SqlCeScripting version 3.5.2.42
CREATE TABLE [SimpleSso] (
  [Token] nvarchar(36) NOT NULL
, [LoginId] nvarchar(100) NOT NULL
, [CreatedDateUtc] datetime NOT NULL
, [Source] nvarchar(200) NOT NULL
);
GO
ALTER TABLE [SimpleSso] ADD CONSTRAINT [PK_SimpleSso] PRIMARY KEY ([Token]);
GO
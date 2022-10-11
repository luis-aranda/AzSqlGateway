---
external help file: AzSqlGateway.dll-Help.xml
Module Name: AzSqlGateway
online version:
schema: 2.0.0
---

# Import-AzSQLGateway

## SYNOPSIS
The cmdlet retrieves all the SQL Gateways located on Microsoft documentation

## SYNTAX

```
Import-AzSQLGateway [-Uri <Uri>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet uses the AgilityPack library to retrieve the data of the Azure SQL DB from Microsoft documentation.

## EXAMPLES

### Example 1
```powershell
PS C:\> Import-AzSqlGateway
```

Gets the entire Azure SQL gateway table

## PARAMETERS

### -Uri
Can be changed if the URL changes at some point

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### AzSqlGateway.SqlGateway

## NOTES

## RELATED LINKS

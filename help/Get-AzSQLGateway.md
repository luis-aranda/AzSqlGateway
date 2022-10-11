---
external help file: AzSqlGateway.dll-Help.xml
Module Name: AzSqlGateway
online version:
schema: 2.0.0
---

# Get-AzSQLGateway

## SYNOPSIS
The cmdlet is a wrapper for Import-AzSqlDatabase

## SYNTAX

```
Get-AzSQLGateway [[-Region] <String>] [<CommonParameters>]
```

## DESCRIPTION
The cmdlet is a wrapper for the Import-AzSqlDatabase cmdlet but also adds a useful parameter to filter by Gateway Region

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzSqlGateway -Region 'East US'
```

Getting the gateway ip address only for East US region

## PARAMETERS

### -Region
Parameter to filter for a specific region

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
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

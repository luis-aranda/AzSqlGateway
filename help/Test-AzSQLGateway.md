---
external help file: AzSqlGateway.dll-Help.xml
Module Name: AzSqlGateway
online version:
schema: 2.0.0
---

# Test-AzSQLGateway

## SYNOPSIS
This cmdlet performs a TCP connection test to port 1433 for the SQL DB gateway

## SYNTAX

```
Test-AzSQLGateway [-SqlGateway <SqlGateway>] [<CommonParameters>]
```

## DESCRIPTION
The cmdlet expects an object in the pipline and procees to test a tcp connection test for each ip address and outbound port 1433

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzSqlGateway -Region 'East US' | Test-AzSqlGateway
```

The cmdlet above gets all the ip addresses from East US region and performs a tcp connection on each outbound address on port 1433

## PARAMETERS

### -SqlGateway
The SqlGateway object which contains the ip addresses

```yaml
Type: SqlGateway
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### AzSqlGateway.SqlGateway

## OUTPUTS

### AzSqlGateway.SqlGatewayTestResult

## NOTES

## RELATED LINKS

sqlcmd `
 -S 192.168.0.32,1433 `
 -d Inventory `
 -U sa `
 -P 'ZAQ!2wsx' `
 -I `
 -i `
    Inventory.Database..sql `
    dbo.Categories.Table.sql `
	dbo.Currencies.Table.sql `
    dbo.Users.Table.sql `
    dbo.Images.Table.sql `
    dbo.Locations.Table.sql `
    dbo.Things.Table.sql `
    dbo.ThingLocations.Table.sql `
 -o output.txt

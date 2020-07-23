sqlcmd `
 -S 192.168.0.32,1433 `
 -d Inventory `
 -U sa `
 -P 'ZAQ!2wsx' `
 -I `
 -i `
    delete.sql `
 -o output.txt

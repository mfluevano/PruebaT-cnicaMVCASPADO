@echo off

set proc_dir=procedimientos
if exist sql.log (
del sql.log
)
echo "--------------------------------------------------------------------------------" >> sql.log
echo "Ejecutando scripts de procedimientos almacenados" >> sql.log
echo "--------------------------------------------------------------------------------" >> sql.log
echo "Archivo |  Estatus" >> log.txt
	
for /r %proc_dir% %%f in (*.sql) do (

echo "Script %%f">> sql.Log
sqlcmd -S localhost /d LabDev /U developer -P abc123ABC -i "%%f" >> sql.log 2>&1

)


set /p name=MigrationName:
dotnet ef migrations --startup-project ../EventRate.Events/ add V_%name% --context ApplicationContext
pause

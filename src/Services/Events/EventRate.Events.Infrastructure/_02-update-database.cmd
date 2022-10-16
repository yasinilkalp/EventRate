set /p id=Ortam:
set ASPNETCORE_ENVIRONMENT=%id%
dotnet ef --startup-project ../EventRate.Events/ database update --context ApplicationContext
pause
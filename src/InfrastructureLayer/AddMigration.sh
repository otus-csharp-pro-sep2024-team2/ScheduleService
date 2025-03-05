dotnet ef migrations add AddEmployeeShift --startup-project ../../src/ScheduleService.Api --project ScheduleService.Infrastructure

printf "\nСоздание миграции завершено"
read  -n 1 -p "Press any key to continue" mainmenuinput
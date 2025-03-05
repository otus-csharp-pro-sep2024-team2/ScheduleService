dotnet ef database update --startup-project ../../src/ScheduleService.Api  --project ScheduleService.Infrastructure

printf "\nДобавление миграции в бд завершено\n"
read  -n 1 -p "Press any key to continue" mainmenuinput

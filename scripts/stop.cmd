docker stop redis & docker rm redis
docker stop nats & docker rm nats

taskkill /f /im valuator.exe
taskkill /f /im rankcalculator.exe

cd ..\nginx\
nginx -s stop
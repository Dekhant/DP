docker stop redis & docker rm redis
docker stop nats & docker rm nats

set NGINX_PATH="../nginx-1.19.7/"

taskkill /f /im valuator.exe
taskkill /f /im rankcalculator.exe
pushd %NGINX_PATH%

nginx -s stop

popd
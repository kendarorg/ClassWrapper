@echo off
call dobuild_env.bat

call dobuild_single ClassWrapper 4.5 net45
call dobuild_single ClassWrapper 4.0 net40

call dobuild_nuget ClassWrapper

pause

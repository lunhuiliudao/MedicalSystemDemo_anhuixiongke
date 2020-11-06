@echo off
rem 说明：Ping -n 这里的10可以改大，改得越大时间越长，按你自己需要改吧。
rem 延迟5秒
ping -n 5 127.0.0.1
Start  MedicalSystem.Updater.Server.exe
  
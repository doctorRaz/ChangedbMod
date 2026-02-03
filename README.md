# ChangeDBmod
>Disclaimer \
[В начале разработки]

Вы тестируете этот код на свой страх и риск\
Если что то поломается я не виноват

 ## [Описание проекта](https://deepwiki.com/doctorRaz/ChangedbMod) [![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/doctorRaz/ChangedbMod)
 
## Сборки для:
- `ChangeDBmod_NC.21-25` nanoCad 21-25
- `ChangeDBmod_NC.26` nanoCad 26
- `ChangedbMod_AC_2024` AutoCAD (c СПДС CS или Механика CS)

### Загрузить сборку соответствующей версии для своего CAD
- nanoCAD `appload`
- AutoCAD `netload`
  
## Назначение: переключение между базами данных MultiCAD
 ### Вызов 
 > `drz_changedb`	Переключение базы данных MultiCAD

### Пример использования
```
;база local SQL
(vl-cmdf "spchangedb" "z:\\BD_SQL\\nana\\std.mdf")

;PostgreSQL
(vl-cmdf "spchangedb" "pgsql:nspds240")

; MS SQL
(vl-cmdf "spchangedb" "SQL:SERVER:mc_spds9")
```




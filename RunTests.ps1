CD .\artifacts\bin\King.Collections.Test.Unit\Release\app

dnvm use 1.0.0-rc1-update1 -r clr -a x64
dnu restore -f .
.\King.Collections.Test.Unit.cmd

CD ../../../../../
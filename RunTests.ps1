CD .\King.Collections.Test.Unit\bin\Debug\dnxcore50

dnvm use 1.0.0-rc1-update1 -r clr -a x64
dnu restore -f
./King.Collections.Test.Unit.cmd

CD ../../../../
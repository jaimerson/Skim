#! /bin/sh

project="Skim"

echo "listing files in $(pwd)"
ls $(pwd)

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -noUpm \
  -silent-crashes \
  -logFile \
  -projectPath "$(pwd)/" \
  -executeMethod BuildScript.Linux \
  -quit

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -noUpm \
  -silent-crashes \
  -logFile \
  -projectPath "$(pwd)/" \
  -executeMethod BuildScript.Windows \
  -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -noUpm \
  -nographics \
  -silent-crashes \
  -logFile \
  -projectPath "$(pwd)/" \
  -executeMethod BuildScript.OSX \
  -quit

echo "Listing files in $(pwd)"
ls $(pwd)
echo "Listing files in $(pwd)/Build/linux"
ls $(pwd)/Build/linux
echo "Listing files in $(pwd)/Build/osx"
ls $(pwd)/Build/osx
echo "Listing files in $(pwd)/Build/windows"
ls $(pwd)/Build/windows

echo 'Attempting to zip builds'
zip -r $(pwd)/Build/linux.zip $(pwd)/Build/linux/
zip -r $(pwd)/Build/mac.zip $(pwd)/Build/osx/
zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/

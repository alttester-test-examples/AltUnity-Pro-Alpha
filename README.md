# AltUnity Pro Alpha Example

This repository shows a few C# tests that use AltUnity Pro Alpha to run automated tests for Unity's Technologies Sample Game "TANKS"


## Make your own WebGL build 

 If you want to build the sample game on the WebGL platform from scratch, you have to follow the next steps:
 - Open the sample project in Unity Editor
 - Make the AltUnity Tester Editor window visible (from AltUnityTools->AltUnity Tester Editor)
 - In the AltUnity Tester Editor window choose WebGL as your desired platform
 - Choose a location for saving the build
 - Make sure you have the 'Run in background' setting enabled
 - Click the "Build & Run" button and wait for the build to start running

## Run the WebGL build from command line

To run the build that is already in our project in the folder "WebGLbuild": 
 - Make sure you have node.js istalled
 - Type in command line the following command 'npm install -g http-server'
 - Go in the build folder location and in command line write 'http-server'
 - From the console, take the provided address to open the game build in browser

## Running the tests on the WebGL platform

- Open AltUnity Pro Alpha and connect to the WebGL build, don't skip this step as your game needs to connect to the proxy in order to run the tests, which is included in AltUnity Pro Alpha
- Expand the tests list in AltUnity Tester Editor
- Select some tests from the test suite named "TanksTests" and click on "Run Selected Tests"

Note: For a better performance, make sure that the tab where you have opened the build is visible on the screen.





# Unity-WebGL-testing-tool
A tool for testing Unity WebGL builds 

Get the tool here : https://badpiggy.itch.io/webgl-tester-for-unity

Currently for windows only. Requires node js to be installed on your machine. ( Contains node js bundled along with the tool for those who don't have it in a separate build )

Features available:
   - Allows you to test your webgl builds locally using node js
   - The following have to be specified through the windows form GUI before launching a server:
   
         1. The path to the folder containing the WebGL files
         2. The port number at which the game will be hosted (default : 3000)
         3. The browser to open the game in 
           (this is optional and a user can instead enter the link by themselves in their preferred browser )
   - The following are mentioned in the cmd window during testing:
   
         1. The link to which the game is hosted
         2. The browser in which the game is opening if a browser has been selected
            (Note:
              Currently, the following browsers are supported for directly opening the link after the server has been initiated
               * Google chrome
               * Firefox
            )
note:
   Once a testing session is finished, a user has to stop the server through the command window created with ctrl+C

# Unity-WebGL-testing-tool
A tool for testing Unity WebGL builds 

Currently for windows only. 

Features available:
   - Allows you to test your webgl builds locally   
   - The following have to be specified before launching a server:
         * The path to the folder containing the WebGL files
         * The port number at which the game will be specified (default : 3000)
         * The browser to open the game in. 
           (this is optional and a user can instead enter the link by themselves in their preferred browser )
   - The following are mentioned in the cmd window during testing:
         * The link to which the game is hosted
         * The browser in which the game is opening if a browser has been selected
            (Note:
              Currently, the following browsers support direct opening of the link
               * Google chrome
               * Firefox
            )
note:
   Once a testing session is finished, a user has to stop the server through the command window created with ctrl+C

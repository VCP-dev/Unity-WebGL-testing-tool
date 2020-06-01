//'use strict';

const express = require('express')
const app = express()
const path = require('path')
const compression = require('compression')
const opn = require('opn');
const chromeopn = require('chrome-opn');

const indexfile = "index.html";
const loaderfile = "Build/UnityLoader.js";

var folderpath;
var portnumber;
var browsername;

app.use(compression())


function initialisation() {
    
    var args = process.argv.slice(2);    
    folderpath = args[0].split('').map((value, index) => { return (value == '~') ? ' ' : value }).join("");
    portnumber = args[1];
    browsername = args[2];
    launch(folderpath, portnumber)
        
}

function launch(pathtofolder,port) {
    app.use(express.static(pathtofolder))
    app.get('*', (req, res) => {
        res.sendFile(__dirname + '/public/error.html')
    })
    var server = app.listen(port, (err) => {
        if (err) {
            console.log("\x1b[31m", "Error while starting server !!!");
        }
        else {
            
            if (browsername != undefined) {
                switch (browsername) {
                    case "chrome":
                        chromeopn('http://localhost:' + port);
                        break;
                    case "firefox":
                        opn('http://localhost:' + port, { app: 'firefox' });
                        break;
                }
                console.log("Game can be played at localhost:" + port + "\nOpening in " + browsername + "\n\nPress Ctrl c to stop the server\n ")

            }
            else {
                console.log("Game can be played at localhost:" + port + "\n\nPress Ctrl c to stop the server\n ")
            }          
            
        }
    })
}

initialisation()


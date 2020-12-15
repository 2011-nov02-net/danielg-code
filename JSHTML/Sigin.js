'use strict';

document.addEventListener('DOMContentLoaded', () => { 
    let submitButton = document.querySelector('#submitButton');
    
    submitButton.addEventListener('click', () => {
        let userName = document.querySelector('#username').value;
        let password = document.querySelector('#password').value;
        console.log('Value: ' + usersName.innerHTML);
        console.log('Value: ' + document.querySelector('#username').value);
        if (userName == "danny" && password == "danny1234") {
            window.location.replace("Welcome.html");
            window.location.href = "Welcome.html";
        }
        else {
            window.alert("Sorry, wrong credentials");
        }
    });
});
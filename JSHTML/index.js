'use strict';

document.addEventListener('DOMContentLoaded', () => { 
    const resultsElement = document.createElement('div');
    const errorElement = document.createElement('div');
    


    function contactApi() {
        //browser gives us object to send HTTP 
        const xhr = new XMLHttpRequest();

        // as a request response cycle occurs, xhrs "ready state" advances from 0 to 4
        //      theres a "ready state change" event that we can use to react to that process

        xhr.addEventListener('readystatechange', () => {
            if (xhr.readyState === 4) {
                // we have the whole response
                if (xhr.status >= 200 && xhr.status <= 299) {
                    //display results somehow 
                    console.log(xhr);
                    resultsElement.textContent = xhr.response.result;
                } else {
                    //display error
                    console.log(xhr);
                    const error = JSON.parse(xhr.responseText).error;

                }
            }
        });

        const url = 'https://newton.now.sh/api/v2/simplify/2^2+2(3)'
        //setting up request but not sent yet
        xhr.open('get', url);
        xhr.setRequestHeader('Accept', 'application/json');
        xhr.responseType = 'json';
        //send request
        xhr.send();

    }
    const form = document.getElementById('calculate-form');
    form.addEventListener('submit', event => {
        event.preventDefault();
        
        contactApi();

    });
});
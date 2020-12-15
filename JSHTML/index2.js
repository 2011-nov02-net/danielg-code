'use strict';

'use strict';

document.addEventListener('DOMContentLoaded', () => { 
    //const resultsElement = document.createElement('div');
    const errorElement = document.createElement('div');
    const resultsElement = document.getElementById('divdiv');
    


    function contactApi() {

        const urlFetch = 'https://newton.now.sh/api/v2/simplify/2^2+2(3)'
        fetch (urlFetch)// returns a promise of a reposne, but the whole body in not downloaded yet.
            .then(response => {
                return response.json(); // returns a promise of the bdoy downloaded and deserialized 
            }).then(obj => {
                resultsElement.textContent = obj.result;
                document.body.appendChild(resultsElement);
            })
            .catch(error => {
                errorElement.textContent = `${errorElement}`;
                document.body.appendChild(errorElement);
            });
    }
    const form = document.getElementById('calculate-form');
    form.addEventListener('submit', event => {
        event.preventDefault();
        
        contactApi();

    });
});
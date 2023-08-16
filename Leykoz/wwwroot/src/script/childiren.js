var t;

fetch('https://Leykoz.az/InfoSlide/GetHeadSlides')
    .then(response => response.json())
    .then(data => {
        var x = "";
        t = data;
        data.forEach(element => {
            x += `
            <div id="${element.id}"  onclick="popupchildiren(this.id)" class="childeren__card">
                <div class="card__image">
                    <img src="${element.imageFile}" alt="">
                </div>

                <div class="card__header">
                    <h1>${element.firstName + " " + element.lastName}</h1>
                </div>

                <div class="card__text">
                    <p>${element.contetnt}</p>
                </div>
            </div>

        `
        });

        document.getElementById('childirens').innerHTML = x;

    })
    .catch(error => console.log(error))


function popupchildiren(click_id) {

    //Popup

    t.forEach(element => {
        if (element.id == click_id) {
            document.querySelector('#main__popup').style.visibility = 'visible';
            document.querySelector('body').style.overflow = 'hidden';
            document.querySelector('body').style.userSelect = 'none';
            (document.querySelector('.popup__text').children[0]).innerHTML = element.firstName + ' ' + element.lastName;
            (document.querySelector('.card__top').children[0]).innerHTML = element.msgTitleContetnt;
            (document.querySelector('.popup__text').children[1]).innerHTML = element.contetnt;
            (document.querySelector('.msgcontent')).innerHTML = element.msgContetnt;
            (document.querySelector('.popup__img').children[0]).setAttribute("src", element.imageFile);
        }
    });

}

document.querySelector('#closechildirens').addEventListener('click', () => {
    document.querySelector('body').style.overflow = 'visible';
    document.querySelector('body').style.userSelect = 'all';
    document.querySelector('#main__popup').style.visibility = 'hidden';
})


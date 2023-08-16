$('.center-slider').slick({
    autoplay: true,
    centerMode: true,
    autoplay: true,
    autoplaySpeed: 2000,
    centerPadding: '85px',
    pauseOnHover: false,
    infinite: true,
    slidesToShow: 3,
    responsive: [
        {
            breakpoint: 1440,
            settings: {
                arrows: false,
                centerPadding: '1px',
                centerMode: true,
                slidesToScroll: 1,
                slidesToShow: 3
            }
        },
        {
            breakpoint: 1280,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '1px',
                slidesToScroll: 1,
                slidesToShow: 3
            }
        },
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: false,
                slidesToScroll: 1,
                slidesToShow: 2
            }
        },
        {
            breakpoint: 500,
            settings: {
                arrows: false,
                centerMode: false,
                centerPadding: '100px',
                slidesToScroll: 1,
                slidesToShow: 1
            }
        }
    ]
});

$('.news__slider').slick({
    dots: false,
    infinite: true,
    arrows: false,
    speed: 300,
    slidesToShow: 3,
    slidesToScroll: 1,
    responsive: [
        {
            breakpoint: 1280,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 3,
                infinite: true,
                dots: false
            }
        },
        {
            breakpoint: 992,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 1,
                infinite: true,
                dots: false
            }
        },

        {
            breakpoint: 768,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                dots: false
            }
        },
        {
            breakpoint: 600,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                dots: false
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                dots: false
            }
        },
        {
            breakpoint: 430,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                dots: false
            }
        }
    ]
});

var t;

//Support Slider
fetch('https://Leykoz.az/InfoSlide/GetHeadSlides')
    .then(response => response.json())
    .then(data => {
        let count = 0;
        data.forEach(element => {
            t = data;

            if (count < 10) {
                $(".support_sliders").append(
                    `
                    <div>
                        <div id="${element.id}" onclick="popupchildiren(this.id)" class="items">
                            <img src="${element.imageFile}" alt="">
                            <div class="contexitemsslider">
                              <h1 class="full__name">${element.firstName + " " + element.lastName}</h1>
                              <p class="info__mans">${element.title}</p>
                            </div>
                        </div>
                    </div>
                
                `
                )
            } else {
                return;
            }

            count++;

        })

    }).then(() => {

    $(".support_sliders").slick({
        dots: true,
        arrows: false,
        infinite: true,
        speed: 300,
        focusOnSelect: true,
        slidesToShow: 4,
        slidesToScroll: 1,
        touchMove: false,
        responsive: [
            {
                breakpoint: 1280,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: false,
                    arrows: false,
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    dots: false,
                    arrows: false,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: false,
                    arrows: false,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: false,
                    arrows: false,

                }
            }
        ]
    });

    //Support Sliders Dots
    document.querySelector('.slick-dots').addEventListener('click', () => {
        document.querySelector('.slick-dots').childNodes.forEach(element => {
            if (element.classList.value === 'slick-active') {
                element.lastChild.innerText < 10 ? document.querySelector('#pagecount').innerHTML = "0" + element.lastChild.innerText : document.querySelector('#pagecount').innerHTML = element.lastChild.innerText;
            }
        });
    });

    document.querySelector('.support__slider').addEventListener('mouseover', () => {
        document.querySelectorAll('[role="presentation"]').forEach(element => {
            if (element.classList == 'slick-active') {
                element.children[0].innerText < 10 ? document.querySelector('#pagecount').innerHTML = "0" + element.children[0].innerText : document.querySelector('#pagecount').innerHTML = element.children[0].innerText;
            }
        });
    })

});

function popupchildiren(click_id) {

    //Popup

    t.forEach(element => {
        if (element.id == click_id) {
            document.querySelector('#main__popup').style.visibility = 'visible';
            document.querySelector('body').style.overflow = 'hidden';
            document.querySelector('body').style.userSelect = 'none';
            (document.querySelector('.popup__text').children[0]).innerHTML = element.firstName + ' ' + element.lastName;
            (document.querySelector('.popup__text').children[1]).innerHTML = element.contetnt;
            (document.querySelector('.card__top').children[0]).innerHTML=element.msgTitleContetnt;
            (document.querySelector('.card__text').children[0]).innerHTML = element.msgContetnt;
            (document.querySelector('.popup__img').children[0]).setAttribute("src", element.imageFile);
        }
    });

}

document.querySelector('#closechildirens').addEventListener('click', () => {
    document.querySelector('#main__popup').style.visibility = 'hidden';
    document.querySelector('body').style.overflow = 'visible';
    document.querySelector('body').style.userSelect = 'all';
})







      
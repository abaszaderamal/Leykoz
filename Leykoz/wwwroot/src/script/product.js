
var t;

fetch("https://Leykoz.az/Product/Getproducts")
.then(response => response.json())
.then(data => {
    t = data;
    var x = "";
    data.forEach(element => {
        x+=`
            
        <div id="${element.id}" onclick="popupproduct(this.id)" class="porduct__card">

            <div class="top__img">
                <img src="${element.imageURL}" alt="">
            </div>

            <p>${element.title}</p>
            <span>${element.price+' '+'AZN'}</span>

        </div>

        `
    });

    document.getElementById('productsallbox').innerHTML = x;

})
.catch(error=>console.log(error))
    
function popupproduct(click_id) {

    //Popup
        
    t.forEach(element => {
        if(element.id == click_id){
            
            document.querySelector('#product__popup').style.visibility = 'visible';
            document.querySelector('body').style.overflow = 'hidden';
            document.querySelector('body').style.userSelect = 'none';
            document.querySelector('.popup__text').children[0].innerHTML = element.title;
            document.querySelector('.productcontent').innerHTML = element.description;                
            document.querySelector('.popup__price').innerHTML = element.price + " AZN";
            document.querySelector('.popup__img').children[0].setAttribute("src",element.imageURL);
        }  
    });


}

document.querySelector('#closeproduct').addEventListener('click',()=>{
    document.querySelector('body').style.overflow = 'visible';
    document.querySelector('body').style.userSelect = 'all';
    document.querySelector('#product__popup').style.visibility = 'hidden';
})

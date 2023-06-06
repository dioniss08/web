    (function() {
      fetch('http://localhost:8080/api/dishes?dividedByType=true').then(res => res.json())
        .then(data => Object.entries(data).forEach(entry => {
          const [key, value] = entry;
          const section = createSection(key);
    
          value.forEach(
            card => {
              section.append(createCard(card.price, card.name, card.photoLink, card.positionId, card.weight));
            }
          )
        }
        ));
    })();
    (function() {
      fetch('http://localhost:8080/api/drinks?dividedByType=true').then(res => res.json())
        .then(data => Object.entries(data).forEach(entry => {
          const [key, value] = entry;
          const section = createSection(key);
    
          value.forEach(
            card => {
              section.append(createCard(card.price, card.name, card.photoLink, card.positionId, card.volume, card.typeOfDrink));
            }
          )
        }
        ));
    })();

    const menu = document.querySelector('.menu');
//-------------------CREATING SECTIONS
function createSection(title) {
  const section = document.createElement('section');
  section.classList.add('menu-section');
  section.setAttribute("id", title);

  const sectionTitle = document.createElement('h2');
  sectionTitle.classList.add('menu-section__title');
  sectionTitle.append(title);
  section.append(sectionTitle);

  const wrapper = document.createElement('div');
  wrapper.classList.add('menu-section__wrapper');
  section.append(wrapper);

  menu.append(section);

  return wrapper;
}


//--------------------------CREATING CARDS
function createCard(price, name, photoLink, positionId, weight) {

  const card = document.createElement('div');
  card.classList.add('card');

  card.setAttribute('id', positionId);

  const cardImg = document.createElement('div');
  cardImg.classList.add('card-img');

  const foodImg = document.createElement('img');
  foodImg.classList.add('food-img');
  foodImg.src = photoLink;

  cardImg.append(foodImg);
  card.append(cardImg);

  const cardTitle = document.createElement('h2');
  cardTitle.classList.add('card-title');
  cardTitle.append(name);
  card.append(cardTitle);

  const cardWeight = document.createElement('p');
  cardWeight.classList.add('card-weight');
  cardWeight.append(weight + " гр.")
  card.append(cardWeight);
  
  const cardPrice = document.createElement('span');
  cardPrice.classList.add('card-price');
  cardPrice.append(price + " грн");
  card.append(cardPrice);

  const buyBtn = document.createElement('button');
  buyBtn.classList.add('add-cart');
  buyBtn.textContent = 'Додати у кошик';
  buyBtn.addEventListener('click', addCart);

  card.append(buyBtn);

  return card;
}

//-------------------CREATING DRINKS CARDS

function createDrinksCard(price, name, photoLink, positionId, volume, typeOfDrink) {

  const card = document.createElement('div');
  card.classList.add('card');

  card.setAttribute('id', positionId);

  const cardImg = document.createElement('div');
  cardImg.classList.add('card-img');

  const foodImg = document.createElement('img');
  foodImg.classList.add('food-img');
  foodImg.src = photoLink;

  cardImg.append(foodImg);
  card.append(cardImg);

  const cardTitle = document.createElement('h2');
  cardTitle.classList.add('card-title');
  cardTitle.append(name);
  card.append(cardTitle);

  const drinkType = document.createElement('p');
  drinkType.classList.add('drink-type');
  drinkType.append("Type: "+ typeOfDrink);
  card.append(drinkType);

  const cardVolume = document.createElement('p');
  cardVolume.classList.add('card-volume');
  cardVolume.append(volume + " ml");
  card.append(cardVolume);

  const cardPrice = document.createElement('span');
  cardPrice.classList.add('card-price');
  cardPrice.append(price + " грн");
  card.append(cardPrice);

  const cartIcon = document.createElement('ion-icon');
  cartIcon.classList.add('add-cart');
  cartIcon.name = 'cart';
  cartIcon.addEventListener('click', addCart);

  card.append(cartIcon);

  return card;
}



//-------------------------CART LOGIC

const btnCart = document.querySelector('#cart-icon');
const cart = document.querySelector('.cart');
const btnClose = document.querySelector('#cart-close');

btnCart.addEventListener('click', () => {
  cart.classList.add('cart-active');
});

btnClose.addEventListener('click', () => {
  cart.classList.remove('cart-active');
});

document.addEventListener('DOMContentLoaded', loadContent);

function loadContent() {
  //Remove Food Items  From Cart
  let btnRemove = document.querySelectorAll('.cart-remove');
  btnRemove.forEach((btn) => {
    btn.addEventListener('click', removeItem);
  });

  //Product Item Change Event
  let qtyElements = document.querySelectorAll('.cart-quantity');
  qtyElements.forEach((input) => {
    input.addEventListener('change', changeQty);
  });

  updateTotal();
}


//Remove Item
function removeItem() {
  if (confirm('Are Your Sure to Remove')) {
    let title = this.parentElement.querySelector('.cart-food-title').innerHTML;
    itemList = itemList.filter(el => el.title != title);
    this.parentElement.remove();
    loadContent();
  }
}

//Change Quantity
function changeQty() {
  if (isNaN(this.value) || this.value < 1) {
    this.value = 1;
  }
  loadContent();
}

let itemList = [];

//Add Cart
function addCart() {
  let food = this.parentElement;
  let title = food.querySelector('.card-title').innerHTML;
  let price = food.querySelector('.card-price').innerHTML;
  let imgSrc = food.querySelector('.food-img').src;
  let positionId = "id" + food.id;
  console.log(positionId);

  let newProduct = { title, price, imgSrc, positionId };

  //Check Product already Exist in Cart
  if (itemList.find((el) => el.title == newProduct.title)) {
    alert("Product Already added in Cart");
    return;
  } else {
    itemList.push(newProduct);
  }


  let newProductElement = createCartProduct(title, price, imgSrc, positionId);
  let element = document.createElement('div');
  element.innerHTML = newProductElement;
  let cartBasket = document.querySelector('.cart-content');
  cartBasket.append(element);
  loadContent();
}


function createCartProduct(title, price, imgSrc, positionId) {

  return `
  <div class="cart-box" id="${positionId}">
  <img src="${imgSrc}" class="cart-img">
  <div class="detail-box">
    <div class="cart-food-title">${title}</div>
    <div class="price-box">
      <div class="cart-price">${price}</div>
       <div class="cart-amt">${price}</div>
   </div>
    <input type="number" value="1" class="cart-quantity">
  </div>
  <ion-icon name="close" class="cart-remove"></ion-icon>
</div>
  `;
}

function updateTotal() {
  const cartItems = document.querySelectorAll('.cart-box');
  const totalValue = document.querySelector('.total-price');

  let total = 0;

  cartItems.forEach(product => {
    let priceElement = product.querySelector('.cart-price');
    let price = parseFloat(priceElement.innerHTML.replace("грн.", ""));
    let qty = product.querySelector('.cart-quantity').value;
    total += (price * qty);
    product.querySelector('.cart-amt').innerText = "грн." + (price * qty);

  });

  totalValue.innerHTML = 'грн.' + total;


  // Add Product Count in Cart Icon

  const cartCount = document.querySelector('.cart-count');
  let count = itemList.length;
  cartCount.innerHTML = count;

  if (count < 0) {
    cartCount.style.display = 'none';
  } else {
    cartCount.style.display = 'block';
  }

}

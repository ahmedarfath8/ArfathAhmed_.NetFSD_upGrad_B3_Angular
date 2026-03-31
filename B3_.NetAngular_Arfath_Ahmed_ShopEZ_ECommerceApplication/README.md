# ShopEZ - Premium Suit Collection

ShopEZ is a frontend e-commerce prototype built using HTML, CSS, JavaScript, Bootstrap 5 and jQuery. This version of the project is presented as a premium suit shopping website where users can browse products, view suit details, manage a cart and simulate checkout.

## Features

- Home page with featured products
- Products page with premium suit collection
- Product details page with brand and suit specifications
- Shopping cart with add, remove and quantity update
- Checkout page with order summary
- LocalStorage cart persistence
- Responsive UI using Bootstrap 5

## Technologies Used

- HTML5
- CSS3
- JavaScript (ES6)
- Bootstrap 5
- jQuery
- JSON
- LocalStorage

## Folder Structure

```text
ShopEZ-Frontend
|
|-- index.html
|-- products.html
|-- product-details.html
|-- cart.html
|-- checkout.html
|
|-- css/
|   |-- styles.css
|
|-- js/
|   |-- common.js
|   |-- products.js
|   |-- cart.js
|   |-- checkout.js
|
|-- data/
|   |-- products.json
|
|-- images/
|   |-- polo-suit.avif
|   |-- louis-suit.avif
|   |-- armani-suit.avif
```

## How to Run

1. Open the project folder in your code editor.
2. Start the project using Live Server or any simple local server.
3. Open `index.html` in the browser.

## Project Flow

1. Product data is stored in `data/products.json`.
2. jQuery loads and displays products dynamically.
3. Users can add items to the cart.
4. Cart data is stored in LocalStorage.
5. Checkout simulates placing an order without real payment.

## Notes

- This is a frontend-only application.
- No backend or payment gateway is connected.
- The project is designed for learning frontend concepts and e-commerce flow.

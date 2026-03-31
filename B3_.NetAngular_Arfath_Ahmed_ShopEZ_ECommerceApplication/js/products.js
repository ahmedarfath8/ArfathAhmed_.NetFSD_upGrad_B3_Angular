$(document).ready(function() {
  if ($("#productsList").length > 0) {
    loadProducts("#productsList");
  }

  if ($("#featuredProducts").length > 0) {
    loadProducts("#featuredProducts", 3);
  }

  if ($("#productDetails").length > 0) {
    loadProductDetails();
  }
});

function loadProducts(targetElement, limit) {
  $.getJSON("data/products.json", function(products) {
    let items = products;

    if (limit) {
      items = products.slice(0, limit);
    }

    displayProducts(items, targetElement);
  });
}

function displayProducts(products, targetElement) {
  let productHtml = "";

  products.forEach(function(product) {
    productHtml += `
      <div class="col-md-4 mb-4">
        <div class="card product-card shadow-sm">
          <img src="${product.image}" class="card-img-top product-image" alt="${product.name}">
          <div class="card-body d-flex flex-column">
            <p class="text-uppercase small text-muted mb-1">${product.brand || "ShopEZ"}</p>
            <h5 class="card-title">${product.name}</h5>
            <p class="card-text text-muted mb-2">Rs. ${product.price}</p>
            <p class="card-text">${product.description.substring(0, 80)}...</p>
            <div class="mt-auto d-flex gap-2">
              <a href="product-details.html?id=${product.id}" class="btn btn-outline-dark btn-sm">View Details</a>
              <button class="btn btn-warning btn-sm add-to-cart-btn" data-id="${product.id}">Add to Cart</button>
            </div>
          </div>
        </div>
      </div>
    `;
  });

  $(targetElement).html(productHtml);
}

function loadProductDetails() {
  const params = new URLSearchParams(window.location.search);
  const productId = Number(params.get("id"));

  $.getJSON("data/products.json", function(products) {
    const product = products.find(function(item) {
      return item.id === productId;
    });

    if (!product) {
      $("#productDetails").html("<p class='text-danger'>Product not found.</p>");
      return;
    }

const productHtml = `
  <div class="row g-4 align-items-center">
    <div class="col-md-6">
      <img src="${product.image}" class="details-image" alt="${product.name}">
    </div>
    <div class="col-md-6">
      <p class="text-uppercase small text-muted mb-1">${product.brand || "ShopEZ"}</p>
      <h1>${product.name}</h1>
      <p class="lead text-muted">Rs. ${product.price}</p>
      <p>${product.description}</p>
      <button class="btn btn-warning add-to-cart-btn" data-id="${product.id}">Add to Cart</button>
    </div>
  </div>
`;

    $("#productDetails").html(productHtml);
  });
}

$(document).on("click", ".add-to-cart-btn", function() {
  const productId = Number($(this).data("id"));

  $.getJSON("data/products.json", function(products) {
    const selectedProduct = products.find(function(product) {
      return product.id === productId;
    });

    if (!selectedProduct) {
      return;
    }

    const cart = getCart();
    const existingItem = cart.find(function(item) {
      return item.id === selectedProduct.id;
    });

    if (existingItem) {
      existingItem.quantity += 1;
    } else {
      cart.push({
        id: selectedProduct.id,
        name: selectedProduct.name,
        price: selectedProduct.price,
        image: selectedProduct.image,
        quantity: 1
      });
    }

    saveCart(cart);
    updateCartCount();
    alert(selectedProduct.name + " added to cart.");
  });
});

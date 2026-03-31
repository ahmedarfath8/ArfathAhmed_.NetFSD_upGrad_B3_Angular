function getCart() {
  return JSON.parse(localStorage.getItem("cart")) || [];
}

function saveCart(cart) {
  localStorage.setItem("cart", JSON.stringify(cart));
}

function updateCartCount() {
  const cart = getCart();
  let totalItems = 0;

  cart.forEach(function(item) {
    totalItems += item.quantity;
  });

  $("#cartCount").text(totalItems);
}

$(document).ready(function() {
  updateCartCount();
});

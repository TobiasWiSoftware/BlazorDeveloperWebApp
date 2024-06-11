
// With JSRuntime injection
window.Blazor = window.Blazor || {};


// very importent - controlles all elements fade in / injected by JSRuntime
window.Blazor.aos_init = function () {
    AOS.init({
        duration: 700,
        easing: "ease-in-out",
        once: true,
        mirror: false
    });
}
// Improved handling of scroll events with proper add/remove event listeners
window.Blazor.registerBackToTop = function (dotNetObject) {
    console.log("scroll triggered");

    // Declare the function explicitly to keep a reference for adding/removing
    const onScroll = function () {
        dotNetObject.invokeMethodAsync('UpdateVisibility', window.scrollY);
    };

    // Add the scroll event listener
    window.addEventListener('scroll', onScroll);

    // Store the function on the dotNetObject for reference during removal
    dotNetObject.onScroll = onScroll;
};

window.Blazor.deregisterBackToTop = function (dotNetObject) {
    // Remove the scroll event listener using the stored reference
    window.removeEventListener('scroll', dotNetObject.onScroll);
};


function registerScrollEvent(dotNetReference) {
    const onScroll = function () {
        dotNetReference.invokeMethodAsync("UpdateActiveLink");
    };

    // Attach event listener
    window.addEventListener('scroll', onScroll);

    // Store the function on the dotNetReference for later removal
    dotNetReference.onScroll = onScroll;
}

function unregisterScrollEvent(dotNetReference) {
    // Detach event listener using the stored reference
    window.removeEventListener('scroll', dotNetReference.onScroll);
}


function scrollToElement(elementId) {
    // Find the element by its ID.
    const element = document.getElementById(elementId);

    // Define the offset from the top of the document. Adjust this value to account
    // for any fixed header or other elements that may obscure the view.
    const headerOffset = 70; // Height of the header, or any fixed top elements.

    // Calculate the position of the element relative to the viewport's top,
    // then adjust it by the current scroll position of the window minus the header offset.
    const elementPosition = element.getBoundingClientRect().top;
    const offsetPosition = elementPosition + window.pageYOffset - headerOffset;

    // Use the scrollTo function with smooth behavior to scroll to the calculated position.
    window.scrollTo({
        top: offsetPosition,
        behavior: "smooth"
    });
}
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
    const element = document.getElementById(elementId);
    const headerOffset = 70; // Adjust based on your header's height
    const elementPosition = element.getBoundingClientRect().top;
    const offsetPosition = elementPosition + window.pageYOffset - headerOffset;

    window.scrollTo({
        top: offsetPosition,
        behavior: "smooth"
    });
}

// Very important bec if removed the content will not be displayed (no JSRuntime injection) ++++++

    /**
 * Easy selector helper function
 */
const select = (el, all = false) => {
    el = el.trim()
    if (all) {
        return [...document.querySelectorAll(el)]
    } else {
        return document.querySelector(el)
    }
}

/**
 * Easy event listener function
 */
const on = (type, el, listener, all = false) => {
    if (all) {
        select(el, all).forEach(e => e.addEventListener(type, listener))
    } else {
        select(el, all).addEventListener(type, listener)
    }
}

/**
 * Easy on scroll event listener 
 */
const onscroll = (el, listener) => {
    el.addEventListener('scroll', listener)
}


// +++++++++


// Attachting the white background on header when scrolling (no JSRuntime inject)
document.addEventListener('scroll', function () {
    var header = document.querySelector('.header');
    if (window.scrollY > 50) {  // Adjust 50 to the scroll position you deem appropriate
        header.classList.add('header-scrolled');
    } else {
        header.classList.remove('header-scrolled');
    }
});




// With JSRuntime injection
window.Blazor = window.Blazor || {};

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
(function () {
    "use strict";


    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    /**
     * Scrolls to an element with header offset
     */
    const scrollto = (el) => {
        let header = select('#header')
        let offset = header.offsetHeight

        if (!header.classList.contains('header-scrolled')) {
            offset -= 10
        }

        let elementPos = select(el).offsetTop
        window.scrollTo({
            top: elementPos - offset,
            behavior: 'smooth'
        })
    }

    /**
     * Toggle .header-scrolled class to #header when page is scrolled
     */
    let selectHeader = select('#header')
    if (selectHeader) {
        const headerScrolled = () => {
            if (window.scrollY > 100) {
                selectHeader.classList.add('header-scrolled')
            } else {
                selectHeader.classList.remove('header-scrolled')
            }
        }
        window.addEventListener('load', headerScrolled)
        onscroll(document, headerScrolled)
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Mobile nav toggle
     */
    on('click', '.mobile-nav-toggle', function (e) {
        select('#navbar').classList.toggle('navbar-mobile')
        this.classList.toggle('bi-list')
        this.classList.toggle('bi-x')
    })

    /**
     * Mobile nav dropdowns activate
     */
    on('click', '.navbar .dropdown > a', function (e) {
        if (select('#navbar').classList.contains('navbar-mobile')) {
            e.preventDefault()
            this.nextElementSibling.classList.toggle('dropdown-active')
        }
    }, true)

    /**
     * Scrool with ofset on links with a class name .scrollto
     */
    on('click', '.scrollto', function (e) {
        if (select(this.hash)) {
            e.preventDefault()

            let navbar = select('#navbar')
            if (navbar.classList.contains('navbar-mobile')) {
                navbar.classList.remove('navbar-mobile')
                let navbarToggle = select('.mobile-nav-toggle')
                navbarToggle.classList.toggle('bi-list')
                navbarToggle.classList.toggle('bi-x')
            }
            scrollto(this.hash)
        }
    }, true)

    /**
     * Scroll with ofset on page load with hash links in the url
     */
    window.addEventListener('load', () => {
        if (window.location.hash) {
            if (select(window.location.hash)) {
                scrollto(window.location.hash)
            }
        }
    });


    /**
     * Animation on scroll
     */
    function aos_init() {
        AOS.init({
            duration: 1000,
            easing: "ease-in-out",
            once: true,
            mirror: false
        });
    }
    window.addEventListener('load', () => {
        aos_init();
    });

    /**
     * Initiate Pure Counter 
     */
    new PureCounter();

})();


document.addEventListener('DOMContentLoaded', function () {
    const sliderContainers = document.querySelectorAll(".slider");

    sliderContainers.forEach(slider => {
        const slides = slider.querySelectorAll(".img-fluid");
        const totalSlides = slides.length;
        let currentIndex = 0;

        function updateSlider() {
            const newTransform = `translateX(-${currentIndex * 100}%)`;
            slider.querySelector(".slides").style.transform = newTransform;
        }

        slider.querySelector(".prev").addEventListener("click", function () {
            currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
            updateSlider();
        });

        slider.querySelector(".next").addEventListener("click", function () {
            currentIndex = (currentIndex + 1) % totalSlides;
            updateSlider();
        });
    });
});





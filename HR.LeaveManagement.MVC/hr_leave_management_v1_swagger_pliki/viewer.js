(function () {
    'use strict';

    /**
     * Add event handlers that allow for collapsing and expanding JSON structures, with the mouse or keyboard.
     */
    function installCollapseEventListeners() {
        // Click handler for collapsing and expanding objects and arrays
        function collapse(evt) {
            let collapser = evt.target;
            while (collapser && (!collapser.classList || !collapser.classList.contains('collapser'))) {
                collapser = collapser.nextSibling;
            }
            if (!collapser || !collapser.classList || !collapser.classList.contains('collapser')) {
                return;
            }
            evt.stopPropagation();
            collapser.classList.toggle('collapsed');
            let collapsible = collapser;
            while (collapsible && (!collapsible.classList || !collapsible.classList.contains('collapsible'))) {
                collapsible = collapsible.nextSibling;
            }
            collapsible.classList.toggle('collapsed');
        }
        /*
         * Collapses the whole json using keyboard
         * TODO: Add a navigator support for each of the elements
         */
        function collapseAll(evt) {
            let inputList;
            let i;
            // Ignore anything paired with a modifier key. See https://github.com/bhollis/jsonview/issues/69
            if (evt.ctrlKey || evt.shiftKey || evt.altKey || evt.metaKey) {
                return;
            }
            if (evt.keyCode === 37) { // Collapses the json on left arrow key up
                inputList = document.querySelectorAll('.collapsible, .collapser');
                for (i = 0; i < inputList.length; i++) {
                    if (inputList[i].parentNode.id !== 'json') {
                        inputList[i].classList.add('collapsed');
                    }
                }
                evt.preventDefault();
            }
            else if (evt.keyCode === 39) { // Expands the json on right arrow key up
                inputList = document.querySelectorAll('.collapsed');
                for (i = 0; i < inputList.length; i++) {
                    inputList[i].classList.remove('collapsed');
                }
                evt.preventDefault();
            }
        }
        // collapse with event delegation
        document.addEventListener('click', collapse, false);
        document.addEventListener('keyup', collapseAll, false);
    }

    document.addEventListener('DOMContentLoaded', installCollapseEventListeners, false);

}());

(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory(require('can-use-dom'), require('simplebar-core')) :
        typeof define === 'function' && define.amd ? define(['can-use-dom', 'simplebar-core'], factory) :
            (global = global || self, global.SimpleBar = factory(global.canUseDOM, global.SimpleBar));
}(this, (function (canUseDOM, SimpleBar) {
    'use strict';

    canUseDOM = canUseDOM && Object.prototype.hasOwnProperty.call(canUseDOM, 'default') ? canUseDOM['default'] : canUseDOM;
    SimpleBar = SimpleBar && Object.prototype.hasOwnProperty.call(SimpleBar, 'default') ? SimpleBar['default'] : SimpleBar;

    var getOptions = function getOptions(obj) {
        var options = Array.prototype.reduce.call(obj, function (acc, attribute) {
            var option = attribute.name.match(/data-simplebar-(.+)/);

            if (option) {
                var key = option[1].replace(/\W+(.)/g, function (x, chr) {
                    return chr.toUpperCase();
                });

                switch (attribute.value) {
                    case 'true':
                        acc[key] = true;
                        break;

                    case 'false':
                        acc[key] = false;
                        break;

                    case undefined:
                        acc[key] = true;
                        break;

                    default:
                        acc[key] = attribute.value;
                }
            }

            return acc;
        }, {});
        return options;
    };

    SimpleBar.initDOMLoadedElements = function () {
        document.removeEventListener('DOMContentLoaded', this.initDOMLoadedElements);
        window.removeEventListener('load', this.initDOMLoadedElements);
        Array.prototype.forEach.call(document.querySelectorAll('[data-simplebar]'), function (el) {
            if (el.getAttribute('data-simplebar') !== 'init' && !SimpleBar.instances.has(el)) new SimpleBar(el, getOptions(el.attributes));
        });
    };

    SimpleBar.removeObserver = function () {
        this.globalObserver.disconnect();
    };

    SimpleBar.initHtmlApi = function () {
        this.initDOMLoadedElements = this.initDOMLoadedElements.bind(this);

        if (typeof MutationObserver !== 'undefined') {

            this.globalObserver = new MutationObserver(SimpleBar.handleMutations);
            this.globalObserver.observe(document, {
                childList: true,
                subtree: true
            });
        }

        if (document.readyState === 'complete' || document.readyState !== 'loading' && !document.documentElement.doScroll) {

            window.setTimeout(this.initDOMLoadedElements);
        } else {
            document.addEventListener('DOMContentLoaded', this.initDOMLoadedElements);
            window.addEventListener('load', this.initDOMLoadedElements);
        }
    };

    SimpleBar.handleMutations = function (mutations) {
        mutations.forEach(function (mutation) {
            Array.prototype.forEach.call(mutation.addedNodes, function (addedNode) {
                if (addedNode.nodeType === 1) {
                    if (addedNode.hasAttribute('data-simplebar')) {
                        !SimpleBar.instances.has(addedNode) && new SimpleBar(addedNode, getOptions(addedNode.attributes));
                    } else {
                        Array.prototype.forEach.call(addedNode.querySelectorAll('[data-simplebar]'), function (el) {
                            if (el.getAttribute('data-simplebar') !== 'init' && !SimpleBar.instances.has(el)) new SimpleBar(el, getOptions(el.attributes));
                        });
                    }
                }
            });
            Array.prototype.forEach.call(mutation.removedNodes, function (removedNode) {
                if (removedNode.nodeType === 1) {
                    if (removedNode.hasAttribute('data-simplebar')) {
                        SimpleBar.instances.has(removedNode) && SimpleBar.instances.get(removedNode).unMount();
                    } else {
                        Array.prototype.forEach.call(removedNode.querySelectorAll('[data-simplebar="init"]'), function (el) {
                            SimpleBar.instances.has(el) && SimpleBar.instances.get(el).unMount();
                        });
                    }
                }
            });
        });
    };

    SimpleBar.getOptions = getOptions;
    SimpleBar.default = SimpleBar;

    if (canUseDOM) {
        SimpleBar.initHtmlApi();
    }

    return SimpleBar;

})));
﻿describe('tree directive', function () {
    beforeEach(module('sfTree'));

    var $rootScope;
    var $q;
    var templateCache;

    beforeEach(inject(function (_$rootScope_, _$q_, $templateCache) {
        $rootScope = _$rootScope_;
        $q = _$q_;
        templateCache = $templateCache;
    }));

    it('[Boyko-Karadzhov] / should request items initially once with null parent.', function () {
        var scope = $rootScope.$new();
        var childrenRequestedCount = 0;
        var requestedParent = 'not null';

        templateCache.put('/Frontend-Assembly/Telerik.Sitefinity.Frontend/sf-tree/dummy.html', '');

        scope.requestChildren = function (parent) {
            childrenRequestedCount++;
            requestedParent = parent;

            var result = $q.defer();
            result.resolve({});
            return result.promise;
        };
        
        var directiveMarkup = '<div sf-tree sf-template-url="sf-tree/dummy.html" sf-request-children="requestChildren(parent)"></div>';
        commonMethods.compileDirective(directiveMarkup, scope);

        expect(childrenRequestedCount).toEqual(1);
        expect(requestedParent).toEqual(null);
    });

    it('[Boyko-Karadzhov] / should request children for item when expanded.', function () {
        var scope = $rootScope.$new();
        var requestedParent = null;
        var requestedWithParentCount = 0;

        templateCache.put('/Frontend-Assembly/Telerik.Sitefinity.Frontend/sf-tree/expand-item.html', '<span ng-click="toggle(node)">{{node.Id}}</span><ul><li ng-repeat="node in node.children" ng-include="sf-tree/expand-item.html"></li></ul>');
        templateCache.put('/Frontend-Assembly/Telerik.Sitefinity.Frontend/sf-tree/expand.html', '<ul><li ng-repeat="node in hierarchy" ng-include="sf-tree/expand-item.html"></li></ul>');

        scope.requestChildren = function (parent) {
            var result = $q.defer();

            if (!parent) {
                result.resolve([{ Id: '1' }, { Id: '2' }]);
            }
            else {
                result.resolve({});
                requestedParent = parent;
                requestedWithParentCount++;
            }

            return result.promise;
        };

        var directiveMarkup = '<div sf-tree sf-template-url="sf-tree/expand.html" sf-request-children="requestChildren(parent)"></div>';
        commonMethods.compileDirective(directiveMarkup, scope);

        $('ul li span:contains("2")').click();
        scope.$digest();

        expect(requestedWithParentCount).toEqual(1);
        expect(requestedParent).toEqual('2');
    });

    it('[Boyko-Karadzhov] / should mark preselected item bound by ng-model as selected.', function () {
        var scope = $rootScope.$new();
        scope.selectedId = '3';

        templateCache.put('/Frontend-Assembly/Telerik.Sitefinity.Frontend/sf-tree/selected-item.html', '<span ng-class="{ \'selected\': isSelected(node) }" ng-click="toggle(node)">{{node.Id}}</span><ul><li ng-repeat="node in node.children" ng-include="sf-tree/selected-item.html"></li></ul>');
        templateCache.put('/Frontend-Assembly/Telerik.Sitefinity.Frontend/sf-tree/expand.html', '<ul><li ng-repeat="node in hierarchy" ng-include="sf-tree/expand-item.html"></li></ul>');

        scope.requestChildren = function (parent) {
            var result = $q.defer();

            if (!parent) {
                result.resolve([{ id: '1' }, { id: '2' }]);
            }
            else if (parent === '2') {
                result.resolve([{ id: '3' }, { id: '4' }]);
            }
            else {
                result.resolve({});
                requestedParent = parent;
                requestedWithParentCount++;
            }

            return result.promise;
        };

        var directiveMarkup = '<div sf-tree ng-model="selectedId" sf-template-url="sf-tree/expand.html" sf-request-children="requestChildren(parent)" sf-identifier="id"></div>';
        commonMethods.compileDirective(directiveMarkup, scope);

        $('ul li span:contains("2")').click();
        scope.$digest();

        expect($('span:contains("3")').is('.selected')).toBe(true);
    });
});
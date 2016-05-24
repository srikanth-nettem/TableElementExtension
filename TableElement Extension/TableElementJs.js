var tableElementFunction = function (tableElement) {
    var rowElements;

    if (!tableElement || typeof (tableElement) !== 'object') {
        throw "not a table element";
    }

    var getRowCount = function () {
        rowElements = tableElement.getElementsByTagName("tr");
        return rowElements.length;
    }

    var getColCount = function () {
        return rowElements[0].getElementsByTagName("td").length + rowElements[0].getElementsByTagName("th").length;
    }

    var getCellText = function (row, col) {
        return rowElements[row].getElementsByTagName("td")[col].textContent;
    }

    var getRowWithCellText = function (text) {
        for (var rowCount = 0; rowCount < rowElements.length; rowCount++) {
            var colElements = rowElements[rowCount].getElementsByTagName("td");
            for (var colCount = 0; colCount < colElements.length; colCount++) {
                if (colElements[colCount].textContent.indexOf(text) >= 0) {
                    return rowCount;
                }
            }
        }
        return -1;
    }

    return {
        rowCount: getRowCount(),
        columnCount: getColCount(),
        getCellText: getCellText,
        getRowWithCellText: getRowWithCellText
    }
};
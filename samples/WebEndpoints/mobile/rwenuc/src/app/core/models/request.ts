export class PageRequest {
    constructor(pageSize: number, pagenNumber: number) {
        this.pageSize = pageSize;
        this.pagenNumber = pagenNumber;
    }
    pageSize: number;
    pagenNumber: number;
}

export class PageResponse<T> {
    constructor() {
        this.items = new Array<T>();
        this.currentPage = 1;
        this.resultsPerPage = 10;
        this.totalPages = 1;
        this.totalResults = 0; 
    }
    currentPage: number;
    resultsPerPage: number;
    totalPages: number;
    totalResults: number;
    items: T[];
}

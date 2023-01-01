import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from "src/environments/environment";
// import { APP_CONFIG, AppConfig } from '@beekin-app/share/app-config'

const headers = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    constructor(private http: HttpClient) { }

    get(element: any, path: string): Observable<any> {
        let httpHeaders = { ...headers, params: element , reportProgress: true}
        return this.http.get(environment.apis.default.url + path, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    postWithLogin(element: any, path: string): Observable<any> {
        if (element == undefined || element == '') {
            element = {}
        }
        let body = new URLSearchParams();
        for (const iterator in element) {
            body.set(iterator, element[iterator]);
        }
        let httpHeaders = {
            headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
        }
        return this.http.post(environment.oAuthConfig.issuer + path, body, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    post(element: any, path: string): Observable<any> {
        if (element == undefined || element == '') {
            element = {}
        }
        let httpHeaders = { ...headers, params: element , reportProgress: true}
        console.log(httpHeaders);
        return this.http.post(environment.apis.default.url + path, element, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    postFormData(element: any, formdata: FormData = undefined, path: string): Observable<any> {
        if (element == undefined || element == '') {
            element = {}
        }
        let httpHeaders = { params: element, reportProgress: true }

        return this.http.post(environment.apis.default.url + path, formdata, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    put(element: any, path: string): Observable<any> {
        let httpHeaders = { ...headers, params: element , reportProgress: true}
        return this.http.put(environment.apis.default.url + path, element, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    delete(element: any, path: string): Observable<any> {
        let httpHeaders = { ...headers, params: element }
        return this.http.delete(environment.apis.default.url + path, httpHeaders).pipe(catchError(this.handleError<any>()))
    }

    postUrlEncoded(element: any, path: string, baseURL: string = environment.apis.default.url): Observable<any> {
        if (element == undefined || element == '') {
            element = {}
        }

        let body = new URLSearchParams();
        for (const iterator in element) {
            body.set(iterator, element[iterator]);
        }
        let httpHeaders = {
            headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
        }
        return this.http.post(baseURL + path, body, httpHeaders).pipe(catchError(this.handleError<any>()))
    }


    /**
       * Handle Http operation that failed.
       * Let the app continue.
       * @param operation - name of the operation that failed
       * @param result - optional value to return as the observable result
       */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            // TODO: send the error to remote logging infrastructure
            console.error(error) // log to console instead

            // TODO: better job of transforming error for user consumption
            //this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T)
        }
    }
}

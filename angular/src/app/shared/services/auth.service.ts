import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ACCESS_TOKEN, REFRESH_TOKEN } from "../constants/keys.const";
import { LoginRequestDto } from "../models/login-request.dto";
import { LoginResponseDto } from "../models/login-response.dto";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(
        private _apiService: ApiService
    ){

    }
    public login(input: LoginRequestDto) : Observable<LoginResponseDto> {
        var body = {
            username: input.username,
            password: input.password,
            client_id: environment.oAuthConfig.clientId,
            client_secret: environment.oAuthConfig.dummyClientSecret,
            grant_type: environment.oAuthConfig.responseType,
            scope: environment.oAuthConfig.scope
        }

        return this._apiService.postWithLogin(body, "/connect/token");
    }

    public isAuthenticated(): boolean {
        return localStorage.getItem(ACCESS_TOKEN) != null;
    }

    public logout() {
        localStorage.removeItem(ACCESS_TOKEN);
        localStorage.removeItem(REFRESH_TOKEN);
    }
}
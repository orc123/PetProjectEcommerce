import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PetProjectEcommerce',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44354/',
    redirectUri: baseUrl,
    clientId: 'PetProjectEcommerce_App',
    responseType: 'code',
    scope: 'offline_access PetProjectEcommerce',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44336',
      rootNamespace: 'PetProjectEcommerce',
    },
  },
} as Environment;

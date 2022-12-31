import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PetProjectEcommerce Admin',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:5000/',
    redirectUri: baseUrl,
    clientId: 'PetProjectEcommerce_Admin',
    responseType: 'code',
    scope: 'PetProjectEcommerce.Admin offline_access',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:5001',
      rootNamespace: 'PetProjectEcommerce.Admin',
    },
  },
} as Environment;
